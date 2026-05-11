namespace PresentationLayer.Views.UserControls
{
  partial class DepartmentListViewUC
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
      this.components = new System.ComponentModel.Container();
      this.DepartmentListDataGridView = new System.Windows.Forms.DataGridView();
      this.optionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.DepartmentListDataGridView)).BeginInit();
      this.optionsContextMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // DepartmentListDataGridView
      // 
      this.DepartmentListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DepartmentListDataGridView.BackgroundColor = System.Drawing.Color.White;
      this.DepartmentListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DepartmentListDataGridView.Location = new System.Drawing.Point(1, 1);
      this.DepartmentListDataGridView.Name = "DepartmentListDataGridView";
      this.DepartmentListDataGridView.ReadOnly = true;
      this.DepartmentListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DepartmentListDataGridView.Size = new System.Drawing.Size(450, 307);
      this.DepartmentListDataGridView.TabIndex = 0;
      this.DepartmentListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.departmentListDataGridView_CellClick);
      this.DepartmentListDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DepartmentListDataGridView_CellMouseLeave);
      this.DepartmentListDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DepartmentListDataGridView_CellMouseMove);
      // 
      // optionsContextMenuStrip
      // 
      this.optionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
      this.optionsContextMenuStrip.Name = "contextMenuStrip1";
      this.optionsContextMenuStrip.Size = new System.Drawing.Size(116, 94);
      // 
      // addToolStripMenuItem
      // 
      this.addToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Add_Icon_Black_Background_01__24x24_;
      this.addToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.addToolStripMenuItem.Name = "addToolStripMenuItem";
      this.addToolStripMenuItem.Size = new System.Drawing.Size(115, 30);
      this.addToolStripMenuItem.Text = "Add";
      this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Edit_Icon_Black_Background_01_24x24_;
      this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(115, 30);
      this.editToolStripMenuItem.Text = "Edit";
      this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Delete_Icon_Black_Background_01_24x24_;
      this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(115, 30);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // DepartmentListViewUC
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.DepartmentListDataGridView);
      this.Name = "DepartmentListViewUC";
      this.Size = new System.Drawing.Size(453, 311);
      this.Load += new System.EventHandler(this.DepartmentListViewUC_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DepartmentListDataGridView)).EndInit();
      this.optionsContextMenuStrip.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView DepartmentListDataGridView;
    private System.Windows.Forms.ContextMenuStrip optionsContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
  }
}
