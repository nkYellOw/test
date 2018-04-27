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
            this.checkBoxAll_OFF = new System.Windows.Forms.CheckBox();
            this.checkBoxAll_ON = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Button_StartScrape = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.downloadGroups = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProxyIp = new System.Windows.Forms.ComboBox();
            this.DownloadDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDownloadPhoto = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(0, 56);
            this.treeView1.Margin = new System.Windows.Forms.Padding(6);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Загрузка категорий...";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(467, 675);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);
            // 
            // checkBoxAll_OFF
            // 
            this.checkBoxAll_OFF.Image = global::scrape_getfpv_com.Properties.Resources.КрасныйКрест;
            this.checkBoxAll_OFF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxAll_OFF.Location = new System.Drawing.Point(194, 6);
            this.checkBoxAll_OFF.Name = "checkBoxAll_OFF";
            this.checkBoxAll_OFF.Size = new System.Drawing.Size(169, 39);
            this.checkBoxAll_OFF.TabIndex = 2;
            this.checkBoxAll_OFF.Text = "TURN OFF";
            this.checkBoxAll_OFF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAll_OFF.UseVisualStyleBackColor = true;
            // 
            // checkBoxAll_ON
            // 
            this.checkBoxAll_ON.Image = global::scrape_getfpv_com.Properties.Resources.Галочка1;
            this.checkBoxAll_ON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxAll_ON.Location = new System.Drawing.Point(6, 6);
            this.checkBoxAll_ON.Name = "checkBoxAll_ON";
            this.checkBoxAll_ON.Size = new System.Drawing.Size(163, 39);
            this.checkBoxAll_ON.TabIndex = 1;
            this.checkBoxAll_ON.Text = "TURN ON";
            this.checkBoxAll_ON.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAll_ON.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(495, 124);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(498, 556);
            this.listBox1.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(492, 692);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(501, 39);
            this.progressBar1.TabIndex = 6;
            // 
            // Button_StartScrape
            // 
            this.Button_StartScrape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_StartScrape.Location = new System.Drawing.Point(495, 57);
            this.Button_StartScrape.Margin = new System.Windows.Forms.Padding(6);
            this.Button_StartScrape.Name = "Button_StartScrape";
            this.Button_StartScrape.Size = new System.Drawing.Size(489, 42);
            this.Button_StartScrape.TabIndex = 5;
            this.Button_StartScrape.Text = "2) Парсить по выделенным группам";
            this.Button_StartScrape.UseVisualStyleBackColor = true;
            this.Button_StartScrape.Click += new System.EventHandler(this.Button_StartScrape_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1010, 777);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.downloadGroups);
            this.tabPage1.Controls.Add(this.checkBoxAll_ON);
            this.tabPage1.Controls.Add(this.checkBoxAll_OFF);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.Button_StartScrape);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1002, 740);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Категории";
            // 
            // downloadGroups
            // 
            this.downloadGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadGroups.Location = new System.Drawing.Point(492, 6);
            this.downloadGroups.Name = "downloadGroups";
            this.downloadGroups.Size = new System.Drawing.Size(492, 42);
            this.downloadGroups.TabIndex = 8;
            this.downloadGroups.Text = "1) Загрузить группы";
            this.downloadGroups.UseVisualStyleBackColor = true;
            this.downloadGroups.Click += new System.EventHandler(this.downloadGroups_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.checkBoxDownloadPhoto);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1002, 740);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ProxyIp);
            this.groupBox1.Controls.Add(this.DownloadDelay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(398, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 179);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy:";
            // 
            // ProxyIp
            // 
            this.ProxyIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyIp.FormattingEnabled = true;
            this.ProxyIp.Items.AddRange(new object[] {
            "139.59.207.66:3128",
            "139.59.53.107:8080",
            "139.59.53.107:3128",
            "138.68.169.8:3128",
            "138.197.58.55:8080",
            "138.68.173.29:8080",
            "183.194.76.254:8060",
            "122.138.168.182:8197",
            "119.127.17.116:808",
            "61.70.7.93:80",
            "151.106.29.126:1080",
            "151.106.29.125:1080",
            "151.106.29.122:1080",
            "139.162.238.54:80",
            "139.59.169.246:3128"});
            this.ProxyIp.Location = new System.Drawing.Point(80, 38);
            this.ProxyIp.Name = "ProxyIp";
            this.ProxyIp.Size = new System.Drawing.Size(512, 32);
            this.ProxyIp.TabIndex = 12;
            // 
            // DownloadDelay
            // 
            this.DownloadDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadDelay.Location = new System.Drawing.Point(472, 87);
            this.DownloadDelay.Name = "DownloadDelay";
            this.DownloadDelay.Size = new System.Drawing.Size(120, 29);
            this.DownloadDelay.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Задержка между загрузкой товаров в сек:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP:";
            // 
            // checkBoxDownloadPhoto
            // 
            this.checkBoxDownloadPhoto.AutoSize = true;
            this.checkBoxDownloadPhoto.Location = new System.Drawing.Point(6, 6);
            this.checkBoxDownloadPhoto.Name = "checkBoxDownloadPhoto";
            this.checkBoxDownloadPhoto.Size = new System.Drawing.Size(181, 29);
            this.checkBoxDownloadPhoto.TabIndex = 4;
            this.checkBoxDownloadPhoto.Text = "Download Photo";
            this.checkBoxDownloadPhoto.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 812);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Scrape getfpv.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadDelay)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button Button_StartScrape;
    private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxAll_OFF;
        private System.Windows.Forms.CheckBox checkBoxAll_ON;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBoxDownloadPhoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button downloadGroups;
        private System.Windows.Forms.NumericUpDown DownloadDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ProxyIp;
    }
}

