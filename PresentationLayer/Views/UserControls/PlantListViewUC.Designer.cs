namespace PresentationLayer.Views.UserControls
{
  partial class PlantListViewUC
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.plantListDataGridView = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.plantListDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // plantListDataGridView
      // 
      this.plantListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.plantListDataGridView.BackgroundColor = System.Drawing.Color.White;
      this.plantListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.plantListDataGridView.Location = new System.Drawing.Point(1, 1);
      this.plantListDataGridView.Name = "plantListDataGridView";
      this.plantListDataGridView.Size = new System.Drawing.Size(530, 432);
      this.plantListDataGridView.TabIndex = 0;
      // 
      // PlantListViewUC
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.plantListDataGridView);
      this.Name = "PlantListViewUC";
      this.Size = new System.Drawing.Size(533, 435);
      this.Load += new System.EventHandler(this.PlantListViewUC_Load);
      ((System.ComponentModel.ISupportInitialize)(this.plantListDataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView plantListDataGridView;
  }
}
