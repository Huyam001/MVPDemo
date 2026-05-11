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
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls
{
  public class DepartmentListPresenter : IDepartmentListPresenter
  {
    public event EventHandler DepartmentListYesDeleteBtnClickEventRaised;

    private IDepartmentListViewUC _departmentListViewUC;
    private IDepartmentServices _departmentServices;
    private IDepartmentDetailPresenter _departmentDetailPresenter;
    private IDepartmentListDeleteView _departmentListDeleteView;

    //BindingList to load with collection of DepartmentModels returned from repository
    //This list will be used to construct the BindingSource for the Views DataGridView
    BindingList<DepartmentSelectDto> _departmentSelectDtoBindingList;

    // This BindingSource binds the list to the DataGridView control.
    private BindingSource _departmentSelectDtoBindingSource;

    public IDepartmentListViewUC GetDepartmentListViewUC()
    {
      return _departmentListViewUC;
    }

    public DepartmentListPresenter(IDepartmentListViewUC departmentListViewUC, IDepartmentServices departmentServices, IDepartmentDetailPresenter departmentDetailPresenter, IDepartmentListDeleteView departmentListDeleteView)
    {
      _departmentListViewUC       = departmentListViewUC;
      _departmentServices         = departmentServices;
      _departmentDetailPresenter  = departmentDetailPresenter;
      _departmentListDeleteView   = departmentListDeleteView;

      SubscribeToEventsSetup();
    }
    private void SubscribeToEventsSetup()
    {
      _departmentListViewUC.DeleteDepartmentMenuClickEventRaised += new EventHandler(OnDeleteSelectedDepartmentInGridMenuClickEventRaised);

      _departmentListViewUC.EditDepartmentMenuClickEventRaised += new EventHandler(OnUpdateSelectedDepartmentInGridMenuClickEventRaised);

      _departmentListViewUC.AddNewDepartmentMenuClickEventRaised += new EventHandler(OnAddNewDepartmentMenuClickEventRaised);

      _departmentListDeleteView.DepartmentListYesDeleteBtnClickEventRaised += new EventHandler(OnDepartmentListYesDeleteBtnClickEventRaised);
    }

    public void OnDepartmentListYesDeleteBtnClickEventRaised(object sender, EventArgs e)
    {
      DepartmentSelectDto departmentSelectDto = (DepartmentSelectDto)_departmentSelectDtoBindingSource.Current;
      _departmentServices.DeleteById(departmentSelectDto.DepartmentId);

      LoadAllDepartmentsFromDbToGrid();
     }

    public void OnDeleteSelectedDepartmentInGridMenuClickEventRaised(object sender, EventArgs e)
    {
      DepartmentSelectDto departmentSelectDto = (DepartmentSelectDto)_departmentSelectDtoBindingSource.Current;

      string DepartNameToDelete = departmentSelectDto.DepartmentName;

      _departmentListDeleteView.ShowDepartmentListDeleteView(DepartNameToDelete);
    }

    public void OnAddNewDepartmentMenuClickEventRaised(object sender, EventArgs e)
    {
      _departmentDetailPresenter.SetupDepartmentForAdd();
    }

    public void OnUpdateSelectedDepartmentInGridMenuClickEventRaised(object sender, EventArgs e)
    {
      DepartmentSelectDto departmentSelectDto = (DepartmentSelectDto)_departmentSelectDtoBindingSource.Current;

      int idOfDepartmentToUpdate = departmentSelectDto.DepartmentId;

      _departmentDetailPresenter.SetupDepartmentForUpdate(idOfDepartmentToUpdate);
    }

    private void BuildDatasourceForAllDepartmentsList()
    {
      IEnumerable<DepartmentSelectDto> allDepartments = _departmentServices.GetDepartmentSelectList();

      _departmentSelectDtoBindingList = new BindingList<DepartmentSelectDto>();
      foreach (DepartmentSelectDto departmentMinimumDetailDto in allDepartments)
      {
        _departmentSelectDtoBindingList.Add(departmentMinimumDetailDto);
      };

      _departmentSelectDtoBindingSource = new BindingSource();//Reset

      this._departmentSelectDtoBindingSource.DataSource = _departmentSelectDtoBindingList;
    }
    
    public void LoadAllDepartmentsFromDbToGrid()
    {
      int rowHeight = 17;

      BuildDatasourceForAllDepartmentsList();

      Dictionary<string, float> gridColumnWidthsDictionary = new Dictionary<string, float>();
      SetDepartmentListViewGridColumnWidths(gridColumnWidthsDictionary);

      Dictionary<string, string> headingsDictionary = new Dictionary<string, string>();
      SetDepartmentListViewGridHeadings(headingsDictionary);

      _departmentListViewUC.LoadDepartmentListToGrid(_departmentSelectDtoBindingSource, headingsDictionary, gridColumnWidthsDictionary, rowHeight);
    }

    private void SetDepartmentListViewGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary)
    {
      gridColumnWidthsDictionary["DepartmentId"] = (float)(.12);
      gridColumnWidthsDictionary["DepartmentName"] = (float)(.40);
      gridColumnWidthsDictionary["CityLocation"] = (float)(.25);
      gridColumnWidthsDictionary["StateLocation"] = (float)(.12);
      gridColumnWidthsDictionary["Options"] = (float)(.15);

    }

    private void SetDepartmentListViewGridHeadings(Dictionary<string, string> headingsDictionary)
    {
      headingsDictionary["DepartmentId"] = "ID";
      headingsDictionary["DepartmentName"] = "Department Name";
      headingsDictionary["CityLocation"] = "City";
      headingsDictionary["StateLocation"] = "State";
      headingsDictionary["OptionsButton"] = "Options";
    }





  }
}
