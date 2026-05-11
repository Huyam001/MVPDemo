/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
  public partial class PlantListViewUC : BaseUserControUC, IPlantListViewUC
  {
    public event EventHandler DisplayAllPlantsBtnClickEventRaised;
    public event EventHandler PlantListViewUCLoadEventRaised;
    public event EventHandler LoadOfAllPlantsIntoGridCompletedEventRaised;

    public PlantListViewUC()
    {
      InitializeComponent();
    }

    public void ShowView()
    {
      this.Show();
    }

    private void PlantListViewUC_Load(object sender, EventArgs e)
    {
      plantListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      plantListDataGridView.AllowUserToAddRows = false; //Removes blank row at end of grid load
      plantListDataGridView.ReadOnly = true;


      EventHelpers.RaiseEvent(this, PlantListViewUCLoadEventRaised, e);
    }

      public void RaisEventDisplayAllPlantsBtnClicked(EventArgs e)
    {
      EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: DisplayAllPlantsBtnClickEventRaised, eventArgs: e);
    }

    public void LoadAllPlantsListToGrid(BindingSource plantListBindingSource,
                                  Dictionary<string, string> headingsDictionary,
                                  Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight)
    {
      this.plantListDataGridView.RowTemplate.Height = rowHeight;

      this.plantListDataGridView.DataSource = plantListBindingSource;

      SetGridHeaderText(headingsDictionary);

      SetGridColumnWidths(gridColumnWidthsDictionary);

      EventHelpers.RaiseEvent(this, LoadOfAllPlantsIntoGridCompletedEventRaised, new EventArgs());
    }
    public void SetGridHeaderText(Dictionary<string, string> headingsDictionary)
    {
      plantListDataGridView.Columns["PlantId"].HeaderText = headingsDictionary["PlantId"];
      plantListDataGridView.Columns["PlantType"].HeaderText = headingsDictionary["PlantType"];
      plantListDataGridView.Columns["PlantColor"].HeaderText = headingsDictionary["PlantColor"];
      plantListDataGridView.Columns["ThumbImage"].HeaderText = headingsDictionary["ThumbImage"];
    }
    public void SetGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary)
    {
      int GridWidth = (plantListDataGridView.Width - plantListDataGridView.RowHeadersWidth -
                 SystemInformation.VerticalScrollBarWidth);

      plantListDataGridView.Columns["PlantId"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["PlantId"]);
      plantListDataGridView.Columns["PlantType"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["PlantType"]);
      plantListDataGridView.Columns["PlantColor"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["PlantColor"]);
      plantListDataGridView.Columns["ThumbImage"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["ThumbImage"]);
    }


  }
}

