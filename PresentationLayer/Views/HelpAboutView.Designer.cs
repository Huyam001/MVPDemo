namespace PresentationLayer.Views
{
  partial class helpAboutView
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
      this.mvpPictureBox = new System.Windows.Forms.PictureBox();
      this.productLabel = new System.Windows.Forms.Label();
      this.versionLabel = new System.Windows.Forms.Label();
      this.copyrightLabel = new System.Windows.Forms.Label();
      this.companyLabel = new System.Windows.Forms.Label();
      this.closeBtn = new System.Windows.Forms.Button();
      this.descriptionLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.mvpPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // mvpPictureBox
      // 
      this.mvpPictureBox.Image = global::PresentationLayer.Properties.Resources.MVPDemo256;
      this.mvpPictureBox.Location = new System.Drawing.Point(65, 12);
      this.mvpPictureBox.Name = "mvpPictureBox";
      this.mvpPictureBox.Size = new System.Drawing.Size(190, 136);
      this.mvpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.mvpPictureBox.TabIndex = 0;
      this.mvpPictureBox.TabStop = false;
      // 
      // productLabel
      // 
      this.productLabel.Location = new System.Drawing.Point(33, 164);
      this.productLabel.Name = "productLabel";
      this.productLabel.Size = new System.Drawing.Size(260, 23);
      this.productLabel.TabIndex = 1;
      this.productLabel.Text = "Product:";
      this.productLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // versionLabel
      // 
      this.versionLabel.Location = new System.Drawing.Point(33, 194);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(260, 23);
      this.versionLabel.TabIndex = 2;
      this.versionLabel.Text = "Version:";
      this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // copyrightLabel
      // 
      this.copyrightLabel.Location = new System.Drawing.Point(33, 224);
      this.copyrightLabel.Name = "copyrightLabel";
      this.copyrightLabel.Size = new System.Drawing.Size(260, 23);
      this.copyrightLabel.TabIndex = 3;
      this.copyrightLabel.Text = "Copyright:";
      this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // companyLabel
      // 
      this.companyLabel.Location = new System.Drawing.Point(33, 254);
      this.companyLabel.Name = "companyLabel";
      this.companyLabel.Size = new System.Drawing.Size(260, 23);
      this.companyLabel.TabIndex = 4;
      this.companyLabel.Text = "Company:";
      this.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // closeBtn
      // 
      this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.closeBtn.Location = new System.Drawing.Point(120, 329);
      this.closeBtn.Name = "closeBtn";
      this.closeBtn.Size = new System.Drawing.Size(75, 23);
      this.closeBtn.TabIndex = 6;
      this.closeBtn.Text = "Close";
      this.closeBtn.UseVisualStyleBackColor = true;
      this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
      // 
      // descriptionLabel
      // 
      this.descriptionLabel.Location = new System.Drawing.Point(36, 282);
      this.descriptionLabel.Name = "descriptionLabel";
      this.descriptionLabel.Size = new System.Drawing.Size(257, 32);
      this.descriptionLabel.TabIndex = 0;
      this.descriptionLabel.Text = "Description";
      // 
      // helpAboutView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(334, 363);
      this.Controls.Add(this.descriptionLabel);
      this.Controls.Add(this.closeBtn);
      this.Controls.Add(this.companyLabel);
      this.Controls.Add(this.copyrightLabel);
      this.Controls.Add(this.versionLabel);
      this.Controls.Add(this.productLabel);
      this.Controls.Add(this.mvpPictureBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "helpAboutView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Help About";
      this.Load += new System.EventHandler(this.HelpAbouView_Load);
      ((System.ComponentModel.ISupportInitialize)(this.mvpPictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox mvpPictureBox;
    private System.Windows.Forms.Label productLabel;
    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.Label copyrightLabel;
    private System.Windows.Forms.Label companyLabel;
    private System.Windows.Forms.Button closeBtn;
    private System.Windows.Forms.Label descriptionLabel;
  }
}