namespace PresentationLayer.Views
{
  partial class DepartmentListDeleteView
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.yesBtn = new System.Windows.Forms.Button();
      this.noBtn = new System.Windows.Forms.Button();
      this.departmentNameToDeleteLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.Delete_Icon_Black_Background_01_24x24_;
      this.pictureBox1.Location = new System.Drawing.Point(29, 28);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(26, 28);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(61, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(234, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Do you want to delete the selected department?";
      // 
      // yesBtn
      // 
      this.yesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.yesBtn.Location = new System.Drawing.Point(82, 70);
      this.yesBtn.Name = "yesBtn";
      this.yesBtn.Size = new System.Drawing.Size(75, 23);
      this.yesBtn.TabIndex = 2;
      this.yesBtn.Text = "Yes";
      this.yesBtn.UseVisualStyleBackColor = true;
      this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
      // 
      // noBtn
      // 
      this.noBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.noBtn.Location = new System.Drawing.Point(179, 70);
      this.noBtn.Name = "noBtn";
      this.noBtn.Size = new System.Drawing.Size(75, 23);
      this.noBtn.TabIndex = 3;
      this.noBtn.Text = "No";
      this.noBtn.UseVisualStyleBackColor = true;
      this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
      // 
      // departmentNameToDeleteLabel
      // 
      this.departmentNameToDeleteLabel.AutoSize = true;
      this.departmentNameToDeleteLabel.Location = new System.Drawing.Point(61, 43);
      this.departmentNameToDeleteLabel.Name = "departmentNameToDeleteLabel";
      this.departmentNameToDeleteLabel.Size = new System.Drawing.Size(234, 13);
      this.departmentNameToDeleteLabel.TabIndex = 4;
      this.departmentNameToDeleteLabel.Text = "Do you want to delete the selected department?";
      // 
      // DepartmentDetailDeleteView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(324, 111);
      this.ControlBox = false;
      this.Controls.Add(this.departmentNameToDeleteLabel);
      this.Controls.Add(this.noBtn);
      this.Controls.Add(this.yesBtn);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DepartmentDetailDeleteView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Confirm Delete";
      this.Load += new System.EventHandler(this.DepartmentListDeleteView_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button yesBtn;
    private System.Windows.Forms.Button noBtn;
    private System.Windows.Forms.Label departmentNameToDeleteLabel;
  }
}