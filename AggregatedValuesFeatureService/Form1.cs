/*
 * Author: Edan Cain, ESRI, 380 New York Street, Redlands, California, 92373, USA. Email: ecain@esri.com Tel: 1-909-793-2853
 * 
 * Code demonstrates how to structure REST calls for interaction with ArcGIS.com organization accounts.
 * Allows the user to log into ArcGIS.com, choose a feature service from within your organization. For the purpose of this
 * sample I have a polygon feature service representing the US States that I have included a count field within. A csv file
 * containing XY data is loaded. A hard coded reference to a publicly exposed US States feature service is used to perform
 * a spatial relationship function to obtain the State that the point falls within. Returning the State name.
 * This name is used to query my State feature layer (the spatial relationship could have been performed on this layer), returning
 * the corresponding record. Obtain from this the Count field selected in the dropdown list of fields (only display numeric fields),
 * get the current value and increment it by one, and update the record to the feature service.
 * 
 * HttpWebResponses are dynamically binded too via the DataContract objects found within the AGOLRestHandler.dll. You 
 * can find this project in GitHub @ https://github.com/ECain.
 * 
 * Code is not supported by ESRI inc, there are no use restrictions, you are free to distribute, modify and use this code.
 * Enhancement or functional code requests should be sent to Edan Cain, ecain@esri.com. 
 * 
 * Code created to help support the Start-up community by the ESRI Emerging Business Team. If you are a start up company,
 * please contact Myles Sutherland at msutherland@esri.com.
 */

using AGOLRestHandler;
using SQLtoFeatureService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AggregatedValuesFeatureService
{
  public partial class Form1 : Form
  {
    JavaScriptSerializer _javaScriptSerializer;
    string _token;
    string _organizationID;
    string _baseApplyEditsURL;
    string _editingRowAttributes;
    Dictionary<string, FeatureLayerAttributes> _featureServiceAttributesDataDictionary;
    Dictionary<string, string> _featureServiceRequestAndResponse;
    FeatureLayerAttributes _featureLayerAttributes;
    FeatureServiceInfo _featureServiceInfo;
    DataTable _dataTable;
    DataRow _editedDataRow;
    FeatureEditsResponse _featureEditResponse;
    StreamReader _sr;
    string _state;

    AGOLRestHandler.GeometryResponse _geometryResponseObject;

    enum EditType
    {
      add,
      delete,
      update
    }
    
    public Form1()
    {
      InitializeComponent();
    }

    private void btnAGOLConnect_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.AppStarting;

      Authentication auth = AuthorizeAgainstArcGISOnline();
      if (auth != null)
        Self();

      this.Cursor = Cursors.Default;
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      openFileDialog1.InitialDirectory = "c:\\";
      openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 0;
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        txtFileLocation.Text = openFileDialog1.FileName;
        _sr = new StreamReader(openFileDialog1.FileName);

        string line = _sr.ReadLine();
        string[] split = line.Split(',');
        cboX.DataSource = split.Clone();
        cboY.DataSource = split.Clone();
      }
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
      ExecuteOperation();
    }

    /// <summary>
    /// Get data on Organizational content, and that of the user specific.
    /// </summary>
    private void Self()
    {
      //self
      this.Cursor = Cursors.WaitCursor;
      string formattedRequest;
      string responseJSON;

      Self response = RequestAndResponseHandler.SelfWebRequest("http://www.arcgis.com/sharing/rest/community/self", _token, out formattedRequest, out responseJSON);

      _organizationID = response.orgId;
      label2.Text = "Self: Organization ID = " + _organizationID;
      _baseApplyEditsURL = txtFeatureServices.Text = string.Format("http://services.arcgis.com/{0}/ArcGIS/rest/services/", response.orgId);
      
      connectToFeatureServices();
      this.Cursor = Cursors.Default;
    }

    private Authentication AuthorizeAgainstArcGISOnline()
    {
      string url = "https://www.arcgis.com/sharing/generatetoken?f=json";
      string jsonTransmission = "username=" + txtAGOUserName.Text + "&password=" + txtAGOPassword.Text + "&expiration=100080&referer=" + "http://startups.maps.arcgis.com/" + "&f=pjson";
      //create a request using the url that can recieve a POST
      string JSON = string.Empty;
      try
      {
        string strOut = string.Empty;
        JSON = RequestAndResponseHandler.HttpWebRequestHelper(url, jsonTransmission, "http://startups.maps.arcgis.com/", out strOut);

        if (JSON.Contains("error"))
        {
          AGOL_Error AGOLError;
          _javaScriptSerializer = new JavaScriptSerializer();
          AGOLError = _javaScriptSerializer.Deserialize<AGOL_Error>(JSON);
          label1.Text = AGOLError.error.code + ". " + AGOLError.error.message + ". " + AGOLError.error.details[0];
          return null;
        }
      }
      catch
      {
        return null;
      }

      JavaScriptSerializer jScriptSerializer = new JavaScriptSerializer();
      Authentication authenticationDataContract = jScriptSerializer.Deserialize<Authentication>(JSON) as Authentication;
      _token = authenticationDataContract.token;
      label1.Text = "Token: " + _token;
      return authenticationDataContract;
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListViewItem item = listBox1.SelectedItem as ListViewItem;
      _featureServiceAttributesDataDictionary.TryGetValue(item.Text, out _featureLayerAttributes);
      _featureServiceInfo = item.Tag as FeatureServiceInfo;

      //supported functionality
      txtSupportedFunctions.Text = _featureLayerAttributes.capabilities;

      //feature service fields
      if (_featureLayerAttributes.fields != null)
        PopulateFieldsList(_featureLayerAttributes.fields);

      //display the default symbol
      ShowSymbol(_featureLayerAttributes);
    }

    private void connectToFeatureServices()
    {
      this.Cursor = Cursors.WaitCursor;
      string formattedRequest = string.Empty;
      string jsonResponse = string.Empty;

      listBox1.Items.Clear();

      //check to see if we have an instantiated dictionary to store the attributes
      if (_featureServiceAttributesDataDictionary == null)
      {
        _featureServiceAttributesDataDictionary = new Dictionary<string, FeatureLayerAttributes>();
        _featureServiceRequestAndResponse = new Dictionary<string, string>();
      }
      else
      {
        _featureServiceAttributesDataDictionary.Clear();
        _featureServiceRequestAndResponse.Clear();
      }

      //query for ServiceLayers. 
      ServiceCatalog serviceCatalogDataContract = RequestAndResponseHandler.GetServiceCatalog(_baseApplyEditsURL, _token, out formattedRequest, out jsonResponse);

      bool executedOnce = false;
      string serviceURL = string.Empty;
      string serviceRequest = string.Empty;
      string serviceResponse = string.Empty;

      foreach (Service service in serviceCatalogDataContract.services)
      {
        //I am only interested in FeatureServices THAT HAVE BEEN SHARED so only get the attributes for this kind of layer
        if (service.type == "FeatureServer")
        {
          //create the entire url string for the layer so we can make the query for attributes
          serviceURL = string.Format("{0}{1}/{2}/0/", _baseApplyEditsURL, service.name, service.type);

          //Feature Layer Attributes
          FeatureLayerAttributes featLayerAttributes = RequestAndResponseHandler.GetFeatureServiceAttributes(serviceURL, _token, out serviceRequest, out serviceResponse);

          //store the request and response so that we can display it to the user when they click each feature service in the list
          _featureServiceRequestAndResponse.Add(service.name, serviceRequest + "$" + serviceResponse);

          //store the attributes
          _featureServiceAttributesDataDictionary.Add(service.name, featLayerAttributes);

          if (executedOnce == false)
          {
            _featureLayerAttributes = featLayerAttributes;

            //display the default symbol
            //ShowSymbol(featLayerAttributes);

            //populate the Field Names
            if (featLayerAttributes.fields != null)
              PopulateFieldsList(featLayerAttributes.fields);
          }

          string url = string.Format("http://services.arcgis.com/{0}/arcgis/rest/services/{1}/FeatureServer?f=pjson", _organizationID, service.name);
          url += "&token=" + _token;
          _featureServiceInfo = RequestAndResponseHandler.GetDataContractInfo(url, DataContractsEnum.FeatureServiceInfo, out jsonResponse) as FeatureServiceInfo;

          //lets store the name of the featureLayer into the listbox
          ListViewItem item = new ListViewItem();
          item.Text = service.name;
          item.Tag = _featureServiceInfo;
          listBox1.Items.Add(item);

          if (executedOnce == false)
          {
            txtSupportedFunctions.Text = _featureServiceInfo.capabilities;
            executedOnce = true;
          }
        }
      }
      listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
      this.Cursor = Cursors.Default;
    }

    private void PopulateFieldsList(object[] p)
    {
      cboFieldNames.Items.Clear();

      if (_dataTable == null)
        _dataTable = new DataTable();

      _dataTable.Rows.Clear();
      _dataTable.Columns.Clear();

      string type;
      var pp = p[0];
      if (pp == null)
        return;

      foreach (var item in p)
      {
        Dictionary<string, object> d = item as Dictionary<string, object>;

        object name;
        d.TryGetValue("name", out name);

        object tpe;
        d.TryGetValue("actualType", out tpe);
        type = tpe.ToString().ToLower();
        if (name == null || tpe == null)
          continue;

        if (name.ToString() == "FID")
          continue;

        if (type == "int" || type == "smallint")
          cboFieldNames.Items.Add(name);
      }
    }

    private void ShowSymbol(FeatureLayerAttributes featLayerAttributes)
    {
      if (featLayerAttributes != null)
      {
        if (featLayerAttributes.drawingInfo != null)
        {
          if (featLayerAttributes.drawingInfo.renderer.symbol != null)
          {
            if (featLayerAttributes.drawingInfo.renderer.symbol.imageData != null)
            {
              //within the JSON response is the serialized image data, use the provided helper function to deserialize it
              System.Drawing.Image image = RequestAndResponseHandler.DeserializeImage(featLayerAttributes.drawingInfo.renderer.symbol.imageData);
              pictureBox1.Image = image;
            }
            else
              pictureBox1.Image = null;
          }
          else
            pictureBox1.Image = null;
        }
        else
          pictureBox1.Image = null;
      }
    }

    private void GeometryWithinUSStateRequest(double x, double y)
    {
      //US State layer used to return the name of the State that the point X, Y is within.
      //It uses the layer itself to perform the geometric operation rather than a Geometry service.
      //If you wanted to use a geometry service you could look here:
      //http://tasks.arcgisonline.com/ArcGIS/rest/services/Geometry/GeometryServer

      string requestURL = "http://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Specialty/ESRI_StateCityHighway_USA/MapServer/1/query?";

      GeometryServiceRequest geometryServiceRequest = new GeometryServiceRequest()
      {
        text = string.Empty,
        geometry = new double[] { x, y },
        geometryType = ESRIGeometryTypes.esriGeometryPoint,
        inSR = null,
        spatialRel = ESRISpatialRelationship.esriSpatialRelWithin,
        relationParam = string.Empty,
        where = string.Empty,
        returnCountOnly = false,
        returnIdsOnly = false,
        returnGeometry = false,
        outFields = null,
        f = "json"
      };

      string payload = RequestPayload(geometryServiceRequest);

      System.Net.HttpWebResponse response = AGOLRestHandler.RequestAndResponseHandler.HttpWebGetRequest(requestURL + payload, "http://startups.maps.arcgis.com");
      string json = AGOLRestHandler.RequestAndResponseHandler.DeserializeResponse(response.GetResponseStream());
      _geometryResponseObject = AGOLRestHandler.RequestAndResponseHandler.GetObjectFromJSON(json, DataContractsEnum.GeometryResponse) as AGOLRestHandler.GeometryResponse;
    }

    private string RequestPayload(GeometryServiceRequest geometryServiceRequest)
    {
      var requestPayload = "";
      var properties = geometryServiceRequest.GetType().GetProperties();
      foreach (var reportField in properties)
      {
        object value = reportField.GetValue(geometryServiceRequest);
        Type type = reportField.GetType();

        Console.WriteLine(reportField.Name);
        Console.WriteLine(value);

        double[] dd = value as double[];
        string[] ss = value as string[];

        if (dd != null)
        {
          requestPayload += reportField.Name + "=" + dd[0] + "," + dd[1] + "&";
        }
        else if (ss != null)
        {
          requestPayload += reportField.Name + "=";
          foreach (string s in ss)
          {
            requestPayload += s + ",";
          }

          requestPayload = requestPayload.Remove(requestPayload.Length - 1, 1); //remove final ','
          requestPayload += "&";
        }
        else
          requestPayload += reportField.Name + "=" + value + "&";
      }

      return requestPayload.Remove(requestPayload.Length - 1, 1); //remove final '&'
    }

    /// <summary>
    /// This operation adds, updates and deletes features to the associated feature layer or table in a single call (POST only). 
    /// The apply edits operation is performed on a feature service layer resource. The results of this operation are 3 arrays of edit results (for adds, updates, and deletes respectively). 
    /// Each edit result identifies a single feature and indicates if the edits were successful or not. If not, it also includes an error code and an error description.  
    /// </summary>
    /// <param name="type"></param>
    private void EditFeatureService(EditType type, string geometryDef, string attributess)
    {
      string formattedRequest = string.Empty;
      string jsonResponse = string.Empty;
      string jsonToSend = string.Empty;
      string attributes = string.Empty;

      string url = CompleteServiceUrl();

      switch (type)
      {
        case EditType.add:
          {
            //NB: implementation from another project. Commented out so that the developer can see how to create this kind of 
            //    REST call, but not of functional importance to what is being displayed herein.

            //if (_dataTable.Rows.Count == 0)
            //  return;

            //object[] row = _dataTable.Rows[_dataTable.Rows.Count - 1].ItemArray;
            //attributes = "\"attributes\":{\"";
            //int counter = 0;
            //foreach (DataColumn column in _dataTable.Columns)
            //{
            //  attributes += string.Format("{0}\":\"{1}\",\"", column.ColumnName, row[counter].ToString());
            //  counter++;
            //}

            //attributes = attributes.Remove(attributes.Length - 2, 2);

            ////NB: Sample does not provide an entry method for the user to enter an XY for the Geom value. 
            ////this is for demo purposes with a point feature service with the spatial ref as below.
            ////Users of this code need to build this functionality into their app, either with text input or map click.
            ////Supplied XY places a point on the Coronado Bridge, San Diego, California
            ////jsonToSend = string.Format("adds=[{\"geometry\":{\"x\":-13041634.9497585,\"y\":3853952.46755234,\"spatialReference\":{\"wkid\":102100, \"latestWkid\" = 3857}},{0}}}]", attributes);
            //jsonToSend = "adds=[{\"geometry\":{\"x\":-13041634.9497585,\"y\":3853952.46755234,\"spatialReference\":{\"wkid\":102100, \"latestWkid\" = 3857}}," + attributes + "}}]";
            break;
          }
        case EditType.delete:
          {
            try
            {
              //NB: implementation from another project. Commented out so that the developer can see how to create this kind of 
              //    REST call, but not of functional importance to what is being displayed herein.

              //jsonToSend = string.Format("deletes={0}", GetSelectedRowFID());
              //_featureEditResponse = RequestAndResponseHandler.FeatureEditRequest(url, jsonToSend, out jsonResponse);
            }
            catch { }
            break;
          }
        case EditType.update:
          {
            jsonToSend = "updates=[{\"" + geometryDef + ",\"spatialReference\":{\"wkid\":102100, \"latestWkid\":3857}},\"" + attributess + "}]";
            break;
          }
        default:
          break;
      }
      _featureEditResponse = RequestAndResponseHandler.FeatureEditRequest(url, jsonToSend, out jsonResponse);
    }

    private string CompleteServiceUrl()
    {
      if (!_baseApplyEditsURL.EndsWith("/"))
        _baseApplyEditsURL += "/";

      ListViewItem item = listBox1.SelectedItem as ListViewItem;
      return string.Format(_baseApplyEditsURL + item.Text + "/FeatureServer/0/applyEdits?f=pjson&token=" + _token);
    }

    private void QueryForRecord(string stateName)
    {
      string jsonResponse;

      string layer = ((ListViewItem)listBox1.SelectedItem).Text;
      string myQueryRESTstring = string.Format("{0}{1}/FeatureServer/0/query?f=json", _baseApplyEditsURL, layer);

      //SQL where clause
      //NB: THIS IS SPECIFIC TO A FEATURE SERVICE THAT CONTAINS ONLY US STATE FEATURES. THE SAMPLE IS SPECIFIC TO AGGREGATING POINT COUNTS WITHIN
      //ANY GIVEN US STATE. IF USING YOUR OWN UNIQUE FEATURE SERVICE TO POPULATE WITH AGGREGATE VALUES, YOU NEED TO MAKE CHANGES TO THE STRING 
      //IMMEDIATELY BELOW TO REFLECT THE QUERY FIELD (i.e. in this instance 'STATE_NAME' is the query field within the STATES feature service).
      //THE UI ONLY PROVIDES YOU WITH A FIELD SELECTION FOR THE FIELD TO HOLD THE AGGREGATED VALUE COUNT

      myQueryRESTstring += string.Format("&where=STATE_NAME = '{0}'&returnGeometry=true&spatialRel=esriSpatialRelIntersects", stateName);
      myQueryRESTstring += "&geometry={\"xmin\":-20037508.342788905,\"ymin\":-6903385.054655023,\"xmax\":-0.000004854053258895874,\"ymax\":13134123.288129028,\"spatialReference\":{\"wkid\":102100}}"; //NB: Spatial extent large enough for the whole of the US
      myQueryRESTstring += "&geometryType=esriGeometryEnvelope&inSR=102100&outFields=*";

      //what is your desired spatial reference of the output geometry? NB: For now simply stating the same as the input
      myQueryRESTstring += string.Format("&outSR={0}&token={1}", _featureLayerAttributes.extent.spatialReference.wkid, _token);

      FeatureQueryResponse obj = RequestAndResponseHandler.FeatureQueryRequest(myQueryRESTstring, out jsonResponse);

      //get the attributes starting index
      int index = jsonResponse.IndexOf("attributes");
      _editingRowAttributes = jsonResponse.Substring(index);

      //get the geometry starting index
      int geometryIndex = _editingRowAttributes.IndexOf("geometry");
      string editingRowGeometry = _editingRowAttributes.Substring(geometryIndex);
      editingRowGeometry = editingRowGeometry.Remove(editingRowGeometry.Length - 4);

      //remove the geometry portion of the string
      _editingRowAttributes = _editingRowAttributes.Remove(geometryIndex);

      //within the attributes, find the field stipulated in the UI as being the aggregation field.
      index = _editingRowAttributes.IndexOf(cboFieldNames.Text);
      string count = _editingRowAttributes.Substring(index + 7);

      //find the location of the end bracket so that we can deal with larger numbers by knowing the length of chars
      int bracket = count.IndexOf("}");

      //get the current aggregated value and increase by 1.
      int val = Convert.ToInt32(count.Substring(0, bracket));
      val++;

      bracket = _editingRowAttributes.IndexOf("}");
      //remove the old value and replace with the new incremented value.
      _editingRowAttributes = _editingRowAttributes.Remove(index + 7, bracket - (index + 7));
      _editingRowAttributes = _editingRowAttributes.Insert(index + 7, val.ToString());
      _editingRowAttributes = _editingRowAttributes.Remove(_editingRowAttributes.Length - 2); //remove the final comma

      //Apply the edit to the feature service.
      EditFeatureService(EditType.update, editingRowGeometry, _editingRowAttributes);
    }

    private void AggregateFeatureServiceValue()
    {
      if (_geometryResponseObject.features.Length > 0)
      {
        IDictionary<string, object> dict = _geometryResponseObject.features[0].attributes as Dictionary<string, object>;

        object statename;
        dict.TryGetValue("STATE_NAME", out statename);
        _state = statename as string;

        if (string.IsNullOrEmpty(_state))
          return;

        QueryForRecord(_state);
      }
    }

    private void ExecuteOperation()
    {
      try
      {
        _sr = new StreamReader(txtFileLocation.Text);

        // Create an instance of StreamReader to read from a file. 
        // The using statement also closes the StreamReader. 
        using (_sr)
        {
          string line = _sr.ReadLine(); //exclude the header line

          string[] split;
          int xIndex = cboX.SelectedIndex;
          int yIndex = cboY.SelectedIndex;
          double X = 0.0;
          double Y = 0.0;

          // Read and display lines from the file until the end of  
          // the file is reached. 
          this.Cursor = Cursors.WaitCursor;
          btnRun.Enabled = false;
          int counter = 0;
          while ((line = _sr.ReadLine()) != null)
          {
            try
            {
              split = line.Split(',');
              X = Convert.ToDouble(split[xIndex]);
              Y = Convert.ToDouble(split[yIndex]);
              GeometryWithinUSStateRequest(X, Y);
              AggregateFeatureServiceValue();
              counter++;
            }
            catch (Exception ee)
            {
              Console.WriteLine(ee.Message);
            }
            finally
            {
              this.Cursor = Cursors.Default;
              lblProcessed.Text = "Processed: " + counter;
              btnRun.Enabled = true;
            }
          }
        }
      }
      catch (Exception ex)
      {
        // Let the user know what went wrong.
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(ex.Message);
      }
    }
  }
}
