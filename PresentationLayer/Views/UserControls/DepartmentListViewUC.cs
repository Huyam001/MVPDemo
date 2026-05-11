/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using DomainLayer.Models.Department;
using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
  public partial class DepartmentListViewUC : BaseUserControUC, IDepartmentListViewUC
  {

    public event EventHandler DepartmentListViewLoadEventRaised;
    public event EventHandler EditDepartmentMenuClickEventRaised;
    public event EventHandler AddNewDepartmentMenuClickEventRaised;
    public event EventHandler DeleteDepartmentMenuClickEventRaised;

    const int columnForGridButton = 4;

    public DepartmentListViewUC()
    {
      InitializeComponent();
    }

    private void DepartmentListViewUC_Load(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, DepartmentListViewLoadEventRaised, e);
    }


    public void ReloadDepartmentListGrid(BindingSource departmentListBindingSource)
    {
      this.DepartmentListDataGridView.DataSource = departmentListBindingSource;
    }

    public void LoadDepartmentListToGrid(BindingSource departmentListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight)
    {
      this.DepartmentListDataGridView.RowTemplate.Height = 32;

      this.DepartmentListDataGridView.DataSource = departmentListBindingSource;

      SetGridHeaderText(headingsDictionary);
      DepartmentListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      DepartmentListDataGridView.AllowUserToAddRows = false; //Removes blank row at end of grid load
      DepartmentListDataGridView.ReadOnly = true;

      int optionsWidth = 0;
      SetGridColumnWidths(gridColumnWidthsDictionary, ref optionsWidth);
/*
      DataGridViewButtonColumn buttonActionColumn = new DataGridViewButtonColumn();
      buttonActionColumn.Name = "Options";
      buttonActionColumn.Text = "Options";
      buttonActionColumn.Width = optionsButtonWidth;


      int columnIndex = 4;
      if (DepartmentListDataGridView.Columns["Options"] == null)
      {
        DepartmentListDataGridView.Columns.Insert(columnIndex, buttonActionColumn);
      }
*/
      // --------------------------------------------

      DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
      imageColumn.HeaderText = "Options";
      imageColumn.Name = "Options";
      imageColumn.Width = optionsWidth;
      imageColumn.Image = Properties.Resources.MoreOptionsBlackDotsOnWhite20x20;
      //int columnIndex = 4;
      if (DepartmentListDataGridView.Columns["Options"] == null)
      {
        DepartmentListDataGridView.Columns.Add(imageColumn);
      }

    }

    private void SetGridHeaderText(Dictionary<string, string> headingsDictionary)
    {
      DepartmentListDataGridView.Columns["DepartmentId"].HeaderText = headingsDictionary["DepartmentId"];
      DepartmentListDataGridView.Columns["DepartmentName"].HeaderText = headingsDictionary["DepartmentName"];
      DepartmentListDataGridView.Columns["CityLocation"].HeaderText = headingsDictionary["CityLocation"];
      DepartmentListDataGridView.Columns["StateLocation"].HeaderText = headingsDictionary["StateLocation"];
    }
    private void SetGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary, ref int optionsWidth)
    {
      int GridWidth = (DepartmentListDataGridView.Width - DepartmentListDataGridView.RowHeadersWidth -
                 SystemInformation.VerticalScrollBarWidth);

      DepartmentListDataGridView.Columns["DepartmentId"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["DepartmentId"]);
      DepartmentListDataGridView.Columns["DepartmentName"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["DepartmentName"]);
      DepartmentListDataGridView.Columns["CityLocation"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["CityLocation"]);
      DepartmentListDataGridView.Columns["StateLocation"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["StateLocation"]);

      optionsWidth = (int)((GridWidth) * gridColumnWidthsDictionary["Options"]);
    }

    private void departmentListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == DepartmentListDataGridView.Columns["Options"].Index)
      {
        optionsContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
      }
    }

    private void addToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OnAddNewDepartmentMenuClick(sender, e);
    }

    private void OnAddNewDepartmentMenuClick(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, AddNewDepartmentMenuClickEventRaised, e);
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OnUpdateSelectedDepartmentInGridMenuClick(sender, e);
    }

    private void OnUpdateSelectedDepartmentInGridMenuClick(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, EditDepartmentMenuClickEventRaised, e);
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, DeleteDepartmentMenuClickEventRaised, e);
    }



    private void DepartmentListDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.ColumnIndex >= 0)
      {
        if (DepartmentListDataGridView.Columns[e.ColumnIndex].Name == "Options")
        {
          Cursor.Current = Cursors.Hand;
        }
      }
    }

    private void DepartmentListDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex >= 0)
      {
        if (DepartmentListDataGridView.Columns[e.ColumnIndex].Name == "Options")
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }


  }
}
