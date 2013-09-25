namespace AggregatedValuesFeatureService
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtOrgURL = new System.Windows.Forms.TextBox();
      this.label17 = new System.Windows.Forms.Label();
      this.btnAGOLConnect = new System.Windows.Forms.Button();
      this.txtAGOPassword = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtAGOUserName = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.txtFeatureServices = new System.Windows.Forms.RichTextBox();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.cboFieldNames = new System.Windows.Forms.ComboBox();
      this.txtSupportedFunctions = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label7 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblProcessed = new System.Windows.Forms.Label();
      this.btnRun = new System.Windows.Forms.Button();
      this.cboY = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.cboX = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.txtFileLocation = new System.Windows.Forms.RichTextBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox2.SuspendLayout();
      this.groupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.txtOrgURL);
      this.groupBox2.Controls.Add(this.label17);
      this.groupBox2.Controls.Add(this.btnAGOLConnect);
      this.groupBox2.Controls.Add(this.txtAGOPassword);
      this.groupBox2.Controls.Add(this.label8);
      this.groupBox2.Controls.Add(this.txtAGOUserName);
      this.groupBox2.Controls.Add(this.label9);
      this.groupBox2.Location = new System.Drawing.Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(499, 383);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "ArcGIS Online";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 292);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 26);
      this.label2.TabIndex = 83;
      this.label2.Text = "Self:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 251);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(77, 26);
      this.label1.TabIndex = 82;
      this.label1.Text = "Token:";
      // 
      // txtOrgURL
      // 
      this.txtOrgURL.Location = new System.Drawing.Point(13, 82);
      this.txtOrgURL.Name = "txtOrgURL";
      this.txtOrgURL.Size = new System.Drawing.Size(471, 31);
      this.txtOrgURL.TabIndex = 81;
      this.txtOrgURL.Text = "http://startups.maps.arcgis.com/";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(13, 49);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(227, 26);
      this.label17.TabIndex = 80;
      this.label17.Text = "Organisation Endpoint";
      // 
      // btnAGOLConnect
      // 
      this.btnAGOLConnect.Location = new System.Drawing.Point(13, 204);
      this.btnAGOLConnect.Name = "btnAGOLConnect";
      this.btnAGOLConnect.Size = new System.Drawing.Size(129, 36);
      this.btnAGOLConnect.TabIndex = 16;
      this.btnAGOLConnect.Text = "Connect";
      this.btnAGOLConnect.UseVisualStyleBackColor = true;
      this.btnAGOLConnect.Click += new System.EventHandler(this.btnAGOLConnect_Click);
      // 
      // txtAGOPassword
      // 
      this.txtAGOPassword.Location = new System.Drawing.Point(139, 159);
      this.txtAGOPassword.Name = "txtAGOPassword";
      this.txtAGOPassword.Size = new System.Drawing.Size(345, 31);
      this.txtAGOPassword.TabIndex = 15;
      this.txtAGOPassword.UseSystemPasswordChar = true;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(8, 162);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(114, 26);
      this.label8.TabIndex = 14;
      this.label8.Text = "Password:";
      // 
      // txtAGOUserName
      // 
      this.txtAGOUserName.Location = new System.Drawing.Point(139, 122);
      this.txtAGOUserName.Name = "txtAGOUserName";
      this.txtAGOUserName.Size = new System.Drawing.Size(345, 31);
      this.txtAGOUserName.TabIndex = 13;
      this.txtAGOUserName.Text = "edan";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(8, 125);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(123, 26);
      this.label9.TabIndex = 12;
      this.label9.Text = "UserName:";
      // 
      // groupBox4
      // 
      this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox4.Controls.Add(this.txtFeatureServices);
      this.groupBox4.Controls.Add(this.listBox1);
      this.groupBox4.Controls.Add(this.cboFieldNames);
      this.groupBox4.Controls.Add(this.txtSupportedFunctions);
      this.groupBox4.Controls.Add(this.label5);
      this.groupBox4.Controls.Add(this.label4);
      this.groupBox4.Controls.Add(this.label6);
      this.groupBox4.Controls.Add(this.pictureBox1);
      this.groupBox4.Controls.Add(this.label7);
      this.groupBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.groupBox4.Location = new System.Drawing.Point(517, 12);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(620, 383);
      this.groupBox4.TabIndex = 19;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Organization Feature Service Info";
      // 
      // txtFeatureServices
      // 
      this.txtFeatureServices.Location = new System.Drawing.Point(9, 34);
      this.txtFeatureServices.Name = "txtFeatureServices";
      this.txtFeatureServices.Size = new System.Drawing.Size(595, 67);
      this.txtFeatureServices.TabIndex = 45;
      this.txtFeatureServices.Text = "";
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 25;
      this.listBox1.Location = new System.Drawing.Point(9, 149);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(594, 154);
      this.listBox1.TabIndex = 41;
      this.listBox1.Tag = "";
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // cboFieldNames
      // 
      this.cboFieldNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboFieldNames.FormattingEnabled = true;
      this.cboFieldNames.Items.AddRange(new object[] {
            "Point",
            "MultiPoint",
            "Polyline",
            "Polygon",
            "Envelope"});
      this.cboFieldNames.Location = new System.Drawing.Point(9, 336);
      this.cboFieldNames.Name = "cboFieldNames";
      this.cboFieldNames.Size = new System.Drawing.Size(437, 33);
      this.cboFieldNames.TabIndex = 39;
      // 
      // txtSupportedFunctions
      // 
      this.txtSupportedFunctions.AutoSize = true;
      this.txtSupportedFunctions.Location = new System.Drawing.Point(9, 629);
      this.txtSupportedFunctions.Name = "txtSupportedFunctions";
      this.txtSupportedFunctions.Size = new System.Drawing.Size(0, 26);
      this.txtSupportedFunctions.TabIndex = 18;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(9, 544);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(99, 26);
      this.label5.TabIndex = 17;
      this.label5.Text = "Supports";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(9, 307);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(239, 26);
      this.label4.TabIndex = 16;
      this.label4.Text = "Field for incrementation";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(9, 426);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(103, 26);
      this.label6.TabIndex = 14;
      this.label6.Text = "Symbol/s";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(9, 455);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(75, 75);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 13;
      this.pictureBox1.TabStop = false;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(9, 110);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(355, 26);
      this.label7.TabIndex = 12;
      this.label7.Text = "List of other Feature Service Layers";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblProcessed);
      this.groupBox1.Controls.Add(this.btnRun);
      this.groupBox1.Controls.Add(this.cboY);
      this.groupBox1.Controls.Add(this.label10);
      this.groupBox1.Controls.Add(this.cboX);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.btnBrowse);
      this.groupBox1.Controls.Add(this.txtFileLocation);
      this.groupBox1.Location = new System.Drawing.Point(517, 401);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(620, 376);
      this.groupBox1.TabIndex = 20;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Location of CSV";
      // 
      // lblProcessed
      // 
      this.lblProcessed.AutoSize = true;
      this.lblProcessed.Location = new System.Drawing.Point(9, 307);
      this.lblProcessed.Name = "lblProcessed";
      this.lblProcessed.Size = new System.Drawing.Size(121, 26);
      this.lblProcessed.TabIndex = 53;
      this.lblProcessed.Text = "Processed:";
      // 
      // btnRun
      // 
      this.btnRun.Location = new System.Drawing.Point(431, 321);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(172, 39);
      this.btnRun.TabIndex = 52;
      this.btnRun.Text = "Run";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // cboY
      // 
      this.cboY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboY.FormattingEnabled = true;
      this.cboY.Items.AddRange(new object[] {
            "Point",
            "MultiPoint",
            "Polyline",
            "Polygon",
            "Envelope"});
      this.cboY.Location = new System.Drawing.Point(9, 240);
      this.cboY.Name = "cboY";
      this.cboY.Size = new System.Drawing.Size(437, 33);
      this.cboY.TabIndex = 51;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(9, 211);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(152, 26);
      this.label10.TabIndex = 50;
      this.label10.Text = "Y Field Name:";
      // 
      // cboX
      // 
      this.cboX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboX.FormattingEnabled = true;
      this.cboX.Items.AddRange(new object[] {
            "Point",
            "MultiPoint",
            "Polyline",
            "Polygon",
            "Envelope"});
      this.cboX.Location = new System.Drawing.Point(9, 166);
      this.cboX.Name = "cboX";
      this.cboX.Size = new System.Drawing.Size(437, 33);
      this.cboX.TabIndex = 49;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 137);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(151, 26);
      this.label3.TabIndex = 48;
      this.label3.Text = "X Field Name:";
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(431, 81);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(172, 39);
      this.btnBrowse.TabIndex = 47;
      this.btnBrowse.Text = "Browse...";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // txtFileLocation
      // 
      this.txtFileLocation.Location = new System.Drawing.Point(9, 37);
      this.txtFileLocation.Name = "txtFileLocation";
      this.txtFileLocation.Size = new System.Drawing.Size(595, 38);
      this.txtFileLocation.TabIndex = 46;
      this.txtFileLocation.Text = "";
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.SystemColors.Control;
      this.textBox1.Enabled = false;
      this.textBox1.Location = new System.Drawing.Point(20, 406);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(476, 371);
      this.textBox1.TabIndex = 21;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1150, 804);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox2);
      this.Name = "Form1";
      this.ShowIcon = false;
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtOrgURL;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Button btnAGOLConnect;
    private System.Windows.Forms.TextBox txtAGOPassword;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtAGOUserName;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.RichTextBox txtFeatureServices;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.ComboBox cboFieldNames;
    private System.Windows.Forms.Label txtSupportedFunctions;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.RichTextBox txtFileLocation;
    private System.Windows.Forms.ComboBox cboY;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.ComboBox cboX;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Label lblProcessed;
    private System.Windows.Forms.TextBox textBox1;
  }
}

