namespace scrape_getfpv_com
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Загрузка категорий...");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAll_OFF = new System.Windows.Forms.CheckBox();
            this.checkBoxAll_ON = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Button_StartScrape = new System.Windows.Forms.Button();
            this.checkBoxDownloadPhoto = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(11, 97);
            this.treeView1.Margin = new System.Windows.Forms.Padding(6);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Загрузка категорий...";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(549, 675);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.checkBoxAll_OFF);
            this.groupBox1.Controls.Add(this.checkBoxAll_ON);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(574, 786);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категории";
            // 
            // checkBoxAll_OFF
            // 
            this.checkBoxAll_OFF.Image = global::scrape_getfpv_com.Properties.Resources.КрасныйКрест;
            this.checkBoxAll_OFF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxAll_OFF.Location = new System.Drawing.Point(180, 49);
            this.checkBoxAll_OFF.Name = "checkBoxAll_OFF";
            this.checkBoxAll_OFF.Size = new System.Drawing.Size(169, 39);
            this.checkBoxAll_OFF.TabIndex = 2;
            this.checkBoxAll_OFF.Text = "TURN OFF";
            this.checkBoxAll_OFF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAll_OFF.UseVisualStyleBackColor = true;
            this.checkBoxAll_OFF.CheckedChanged += new System.EventHandler(this.checkBoxAll_OFF_CheckedChanged);
            // 
            // checkBoxAll_ON
            // 
            this.checkBoxAll_ON.Image = global::scrape_getfpv_com.Properties.Resources.Галочка1;
            this.checkBoxAll_ON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxAll_ON.Location = new System.Drawing.Point(11, 49);
            this.checkBoxAll_ON.Name = "checkBoxAll_ON";
            this.checkBoxAll_ON.Size = new System.Drawing.Size(163, 39);
            this.checkBoxAll_ON.TabIndex = 1;
            this.checkBoxAll_ON.Text = "TURN ON";
            this.checkBoxAll_ON.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAll_ON.UseVisualStyleBackColor = true;
            this.checkBoxAll_ON.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(610, 124);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(549, 604);
            this.listBox1.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(607, 755);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(552, 42);
            this.progressBar1.TabIndex = 6;
            // 
            // Button_StartScrape
            // 
            this.Button_StartScrape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_StartScrape.Location = new System.Drawing.Point(607, 22);
            this.Button_StartScrape.Margin = new System.Windows.Forms.Padding(6);
            this.Button_StartScrape.Name = "Button_StartScrape";
            this.Button_StartScrape.Size = new System.Drawing.Size(552, 42);
            this.Button_StartScrape.TabIndex = 5;
            this.Button_StartScrape.Text = "Старт";
            this.Button_StartScrape.UseVisualStyleBackColor = true;
            this.Button_StartScrape.Click += new System.EventHandler(this.Button_StartScrape_Click);
            // 
            // checkBoxDownloadPhoto
            // 
            this.checkBoxDownloadPhoto.AutoSize = true;
            this.checkBoxDownloadPhoto.Location = new System.Drawing.Point(610, 81);
            this.checkBoxDownloadPhoto.Name = "checkBoxDownloadPhoto";
            this.checkBoxDownloadPhoto.Size = new System.Drawing.Size(181, 29);
            this.checkBoxDownloadPhoto.TabIndex = 3;
            this.checkBoxDownloadPhoto.Text = "Download Photo";
            this.checkBoxDownloadPhoto.UseVisualStyleBackColor = true;
            this.checkBoxDownloadPhoto.CheckedChanged += new System.EventHandler(this.checkBoxDownloadPhoto_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 831);
            this.Controls.Add(this.checkBoxDownloadPhoto);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Button_StartScrape);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Парсер getfpv.com - Scrape Studio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button Button_StartScrape;
    private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxAll_OFF;
        private System.Windows.Forms.CheckBox checkBoxAll_ON;
        private System.Windows.Forms.CheckBox checkBoxDownloadPhoto;
    }
}

