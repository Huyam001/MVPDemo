/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.PlantServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls
{
  public class PlantListPresenter : IPlantListPresenter
  {
    private IPlantListViewUC _plantListViewUC;
    private IPlantServices _plantServices;

    //private Panel _displayPanelForUserControls;

    BindingSource _plantListBindingSource;

    public IPlantListViewUC GetPlantListViewUC()
    {
      return _plantListViewUC;
    }


    public PlantListPresenter(IPlantListViewUC plantListViewUC, IPlantServices plantServices)
    {
      _plantListViewUC = plantListViewUC;

      _plantListViewUC.ShowView();

      _plantServices = plantServices;
    }


    public void LoadAllPlantsFromDbToGrid()
    {
      GetAllPlantsListForGridLoad();
    }

    public void GetAllPlantsListForGridLoad()
    {
      _plantListBindingSource = new BindingSource();

      _plantServices.BuildDatasourceForAllPlantsList(_plantListBindingSource);

      Dictionary<string, string> headingsDictionary = new Dictionary<string, string>();
      Dictionary<string, float> gridColumnWidthsDictionary = new Dictionary<string, float>();

      SetPlantViewGridHeadings(headingsDictionary);

      SetPlantViewGridColumnWidths(gridColumnWidthsDictionary);

       const int rowHeight = 75;

      LoadAllPlantsListToGrid(_plantListBindingSource, headingsDictionary, gridColumnWidthsDictionary, rowHeight);
    }

    private void LoadAllPlantsListToGrid(BindingSource bindingSource, Dictionary<string, string> headingsDictionary, 
                                         Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight)
    {
      _plantListViewUC.LoadAllPlantsListToGrid(bindingSource, headingsDictionary, gridColumnWidthsDictionary, rowHeight);
    }

    private void SetPlantViewGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary)
    {
      gridColumnWidthsDictionary["PlantId"] = (float)(.20);
      gridColumnWidthsDictionary["PlantType"] = (float)(.25);
      gridColumnWidthsDictionary["PlantColor"] = (float)(.25);
      gridColumnWidthsDictionary["ThumbImage"] = (float)(.30);
    }

    private void SetPlantViewGridHeadings(Dictionary<string, string> headingsDictionary)
    {
      headingsDictionary["ThumbImage"] = "Picture";
      headingsDictionary["PlantType"] = "Type";
      headingsDictionary["PlantColor"] = "Color";
      headingsDictionary["PlantId"] = "Id";
    }






  }




}
