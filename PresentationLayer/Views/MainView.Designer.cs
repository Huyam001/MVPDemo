namespace PresentationLayer.Views
{
  partial class MainView
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
      this.userControlPanel = new System.Windows.Forms.Panel();
      this.departmentsBtn = new System.Windows.Forms.Button();
      this.plantsBtn = new System.Windows.Forms.Button();
      this.newsBtn = new System.Windows.Forms.Button();
      this.DepartmentDetailTimer = new System.Windows.Forms.Timer(this.components);
      this.underlineLabel = new System.Windows.Forms.Label();
      this.optionsPanel = new System.Windows.Forms.Panel();
      this.notificationBellPictureBox = new System.Windows.Forms.PictureBox();
      this.moreOptionsPictureBox = new System.Windows.Forms.PictureBox();
      this.userInfoPictureBox = new System.Windows.Forms.PictureBox();
      this.moreOptionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.gardenPictureBox = new System.Windows.Forms.PictureBox();
      this.optionsPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.notificationBellPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.moreOptionsPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.userInfoPictureBox)).BeginInit();
      this.moreOptionsContextMenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gardenPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // userControlPanel
      // 
      this.userControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.userControlPanel.BackColor = System.Drawing.Color.White;
      this.userControlPanel.Location = new System.Drawing.Point(1, 181);
      this.userControlPanel.Name = "userControlPanel";
      this.userControlPanel.Size = new System.Drawing.Size(379, 278);
      this.userControlPanel.TabIndex = 0;
      // 
      // departmentsBtn
      // 
      this.departmentsBtn.FlatAppearance.BorderSize = 0;
      this.departmentsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.departmentsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.departmentsBtn.Location = new System.Drawing.Point(134, 148);
      this.departmentsBtn.Margin = new System.Windows.Forms.Padding(0);
      this.departmentsBtn.Name = "departmentsBtn";
      this.departmentsBtn.Size = new System.Drawing.Size(98, 23);
      this.departmentsBtn.TabIndex = 6;
      this.departmentsBtn.Text = "Departments";
      this.departmentsBtn.UseVisualStyleBackColor = true;
      this.departmentsBtn.Click += new System.EventHandler(this.DepartmentsBtn_Click);
      // 
      // plantsBtn
      // 
      this.plantsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.plantsBtn.Location = new System.Drawing.Point(69, 148);
      this.plantsBtn.Name = "plantsBtn";
      this.plantsBtn.Size = new System.Drawing.Size(55, 23);
      this.plantsBtn.TabIndex = 5;
      this.plantsBtn.Text = "Plants";
      this.plantsBtn.UseVisualStyleBackColor = true;
      this.plantsBtn.Click += new System.EventHandler(this.PlantsBtn_Click);
      // 
      // newsBtn
      // 
      this.newsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.newsBtn.Location = new System.Drawing.Point(12, 148);
      this.newsBtn.Name = "newsBtn";
      this.newsBtn.Size = new System.Drawing.Size(51, 23);
      this.newsBtn.TabIndex = 4;
      this.newsBtn.Text = "News";
      this.newsBtn.UseVisualStyleBackColor = true;
      this.newsBtn.Click += new System.EventHandler(this.NewsBtn_Click);
      // 
      // DepartmentDetailTimer
      // 
      this.DepartmentDetailTimer.Interval = 5;
      this.DepartmentDetailTimer.Tick += new System.EventHandler(this.departmentDetailTimer_Tick);
      // 
      // underlineLabel
      // 
      this.underlineLabel.BackColor = System.Drawing.Color.Black;
      this.underlineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.underlineLabel.Location = new System.Drawing.Point(134, 167);
      this.underlineLabel.Name = "underlineLabel";
      this.underlineLabel.Size = new System.Drawing.Size(97, 4);
      this.underlineLabel.TabIndex = 9;
      this.underlineLabel.Text = "label1";
      // 
      // optionsPanel
      // 
      this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.optionsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("optionsPanel.BackgroundImage")));
      this.optionsPanel.Controls.Add(this.notificationBellPictureBox);
      this.optionsPanel.Controls.Add(this.moreOptionsPictureBox);
      this.optionsPanel.Controls.Add(this.userInfoPictureBox);
      this.optionsPanel.Location = new System.Drawing.Point(0, -1);
      this.optionsPanel.Name = "optionsPanel";
      this.optionsPanel.Size = new System.Drawing.Size(380, 49);
      this.optionsPanel.TabIndex = 7;
      // 
      // notificationBellPictureBox
      // 
      this.notificationBellPictureBox.BackColor = System.Drawing.Color.Black;
      this.notificationBellPictureBox.Image = global::PresentationLayer.Properties.Resources.Bell_Notification;
      this.notificationBellPictureBox.Location = new System.Drawing.Point(284, 11);
      this.notificationBellPictureBox.Name = "notificationBellPictureBox";
      this.notificationBellPictureBox.Size = new System.Drawing.Size(24, 24);
      this.notificationBellPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.notificationBellPictureBox.TabIndex = 11;
      this.notificationBellPictureBox.TabStop = false;
      // 
      // moreOptionsPictureBox
      // 
      this.moreOptionsPictureBox.BackColor = System.Drawing.Color.Black;
      this.moreOptionsPictureBox.Image = global::PresentationLayer.Properties.Resources.Menu_Of_3_Dots;
      this.moreOptionsPictureBox.Location = new System.Drawing.Point(347, 11);
      this.moreOptionsPictureBox.Name = "moreOptionsPictureBox";
      this.moreOptionsPictureBox.Size = new System.Drawing.Size(24, 24);
      this.moreOptionsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.moreOptionsPictureBox.TabIndex = 11;
      this.moreOptionsPictureBox.TabStop = false;
      this.moreOptionsPictureBox.Click += new System.EventHandler(this.moreOptionsPictureBox_Click);
      // 
      // userInfoPictureBox
      // 
      this.userInfoPictureBox.BackColor = System.Drawing.Color.Black;
      this.userInfoPictureBox.Image = global::PresentationLayer.Properties.Resources.UserIconWhiteSpheres;
      this.userInfoPictureBox.Location = new System.Drawing.Point(318, 10);
      this.userInfoPictureBox.Name = "userInfoPictureBox";
      this.userInfoPictureBox.Size = new System.Drawing.Size(24, 24);
      this.userInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.userInfoPictureBox.TabIndex = 10;
      this.userInfoPictureBox.TabStop = false;
      this.userInfoPictureBox.Click += new System.EventHandler(this.userPictureBox_Click);
      // 
      // moreOptionsContextMenuStrip
      // 
      this.moreOptionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.moreOptionsContextMenuStrip.Name = "moreOptionsContextMenuStrip";
      this.moreOptionsContextMenuStrip.Size = new System.Drawing.Size(136, 70);
      // 
      // helpAboutToolStripMenuItem
      // 
      this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
      this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.helpAboutToolStripMenuItem.Text = "Help About";
      this.helpAboutToolStripMenuItem.Click += new System.EventHandler(this.helpAboutToolStripMenuItem_Click);
      // 
      // SettingsToolStripMenuItem
      // 
      this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
      this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.SettingsToolStripMenuItem.Text = "Settings";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // gardenPictureBox
      // 
      this.gardenPictureBox.Image = global::PresentationLayer.Properties.Resources.FlowerShrubLine;
      this.gardenPictureBox.Location = new System.Drawing.Point(0, 47);
      this.gardenPictureBox.Name = "gardenPictureBox";
      this.gardenPictureBox.Size = new System.Drawing.Size(380, 88);
      this.gardenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.gardenPictureBox.TabIndex = 10;
      this.gardenPictureBox.TabStop = false;
      // 
      // MainView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(380, 456);
      this.Controls.Add(this.gardenPictureBox);
      this.Controls.Add(this.underlineLabel);
      this.Controls.Add(this.optionsPanel);
      this.Controls.Add(this.departmentsBtn);
      this.Controls.Add(this.plantsBtn);
      this.Controls.Add(this.newsBtn);
      this.Controls.Add(this.userControlPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "MainView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Model View Presenter Demo ";
      this.Load += new System.EventHandler(this.MainView_Load);
      this.optionsPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.notificationBellPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.moreOptionsPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.userInfoPictureBox)).EndInit();
      this.moreOptionsContextMenuStrip.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gardenPictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel userControlPanel;
    private System.Windows.Forms.Button departmentsBtn;
    private System.Windows.Forms.Button plantsBtn;
    private System.Windows.Forms.Button newsBtn;
    private System.Windows.Forms.Timer DepartmentDetailTimer;
    private System.Windows.Forms.Panel optionsPanel;
    private System.Windows.Forms.Label underlineLabel;
    private System.Windows.Forms.PictureBox userInfoPictureBox;
    private System.Windows.Forms.PictureBox moreOptionsPictureBox;
    private System.Windows.Forms.PictureBox notificationBellPictureBox;
    private System.Windows.Forms.ContextMenuStrip moreOptionsContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem helpAboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.PictureBox gardenPictureBox;
  }
}