using AGOLRestHandler;
using System.Runtime.Serialization;

namespace AggregatedValuesFeatureService
{
  [DataContract]
  public class GeometryServiceRequest
  {
    [DataMember]
    public string text { get; set;}

    [DataMember]
    public double[] geometry { get; set; }

    [DataMember]
    public ESRIGeometryTypes geometryType { get; set; }

    [DataMember]
    public SpatialReference inSR { get; set; }

    [DataMember]
    public ESRISpatialRelationship spatialRel { get; set; }

    [DataMember]
    public string relationParam { get; set; }

    [DataMember]
    public object objectIds { get; set; }
  
    [DataMember]
    public string where { get; set; } 

    [DataMember]
    public object time { get; set; }

    [DataMember]
    public bool returnCountOnly { get; set; }

    [DataMember]
    public bool returnIdsOnly { get; set; }

    [DataMember]
    public bool returnGeometry { get; set; }

    [DataMember]
    public object maxAllowableOffset { get; set; }
  
    [DataMember]
    public SpatialReference outSR { get; set; }

    [DataMember]
    public object[] outFields { get; set; }

    [DataMember]
    public string f { get; set; }
  }
}
