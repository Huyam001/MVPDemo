/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using CommonComponets;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
  public class MainPresenter : BasePresenter, IMainPresenter
  {
    //public event EventHandler DepartmentDetailViewBindingDoneEventRaised;

       
    IMainView _mainView;
    Panel _userControlPanel;
    private IPlantListPresenter _plantListPresenter;
    private INewsPresenter _newsPresenter;
    private IDepartmentListPresenter _departmentListPresenter;
    private IDepartmentDetailPresenter _departmentDetailPresenter;
    private IHelpAboutPresenter _helpAboutPresenter;

    private List<UserControl> _userControList;

    public IMainView GetMainView() { return _mainView; }
    public void SetMainView(IMainView mainView) { _mainView = mainView; }

    public MainPresenter()
    {

    }

    public MainPresenter(IMainView mainView, IPlantListPresenter plantListPresenter, INewsPresenter newsPresenter, IDepartmentListPresenter departmentListPresenter, IDepartmentDetailPresenter departmentDetailPresenter, IHelpAboutPresenter helpAboutPresenter, IErrorMessageView errorMessageView) : base(errorMessageView)
    {
      _mainView                  = mainView;
      _userControlPanel          = _mainView.GetUserControlPanel();
      _plantListPresenter        = plantListPresenter;
      _newsPresenter             = newsPresenter;
      _departmentListPresenter   = departmentListPresenter;
      _departmentDetailPresenter = departmentDetailPresenter;
      _helpAboutPresenter        = helpAboutPresenter;
      SubscribeToEventsSetup();
    }

    private void SubscribeToEventsSetup()
    {
      _mainView.PlantsListBtnClickEventRaised += new EventHandler(OnPlantsListBtnClickEventRaised);

      _mainView.DepartmentListBtnClickEventRaised += new EventHandler(OnDepartmentListBtnClickEventRaised);

      _mainView.NewsBtnClickEventRaised += new EventHandler(OnDisplayNewsBtnClickEventRaised);

      _mainView.MainViewLoadedEventRaised += new EventHandler(OnMainViewLoadedEventRaised);

      _departmentDetailPresenter.DepartmentDetailViewReadyToShowEventRaised += new EventHandler(OnDepartmentDetailViewReadyToShowEventRaised);

      _departmentDetailPresenter.DepartmentDetailSaveBtnClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnDepartmentDetailSaveBtnClickEventRaised);

      _departmentDetailPresenter.DepartmentDetailCancelBtnClickEventRaised += new EventHandler(OnDepartmentDetailCancelBtnClickEventRaised);

      _mainView.HelpAboutMenuClickEventRaised += new EventHandler(OnHelpAboutMenuClickEventRaised);

    }

    public void OnMainViewLoadedEventRaised(object sender, System.EventArgs e)
    {
      _userControList = new List<UserControl>();
      _userControList.Add((UserControl)_newsPresenter.GetNewsViewUC());
      _userControList.Add((UserControl)_plantListPresenter.GetPlantListViewUC());
      _userControList.Add((UserControl)_departmentListPresenter.GetDepartmentListViewUC());
      _userControList.Add((UserControl)_departmentDetailPresenter.GetDepartmentDetailViewUC());

      AssignUserControlToMainViewPanel((BaseUserControUC)_plantListPresenter.GetPlantListViewUC());
      AssignUserControlToMainViewPanel((BaseUserControUC)_departmentListPresenter.GetDepartmentListViewUC());
      AssignUserControlToMainViewPanel((BaseUserControUC)_newsPresenter.GetNewsViewUC());
      AssignUserControlToMainViewPanel((BaseUserControUC)_departmentDetailPresenter.GetDepartmentDetailViewUC());
      SetUserControlVisibleInPanel((UserControl)_newsPresenter.GetNewsViewUC());
      _newsPresenter.LoadNewsPageIntoNewsView();
    }

    public void OnHelpAboutMenuClickEventRaised(object sender, EventArgs e)
    {
      _helpAboutPresenter.GetHelpAboutView().ShowHelpAboutView();
    }

    public void OnDepartmentDetailSaveBtnClickEventRaised(object sender, AccessTypeEventArgs e)
    {
      UpdateUserControlPanelForDepartmentDetailViewExit(e);
    }

    public void OnDepartmentDetailCancelBtnClickEventRaised(object sender, EventArgs e)
    {
      _mainView.ResetUserControlPanelSizeandLocation();
      SetUserControlVisibleInPanel((UserControl)_departmentListPresenter.GetDepartmentListViewUC());
    }

    public void UpdateUserControlPanelForDepartmentDetailViewExit(AccessTypeEventArgs e)
    {
      _mainView.ResetUserControlPanelSizeandLocation();
      SetupDepartmentListInPanel();
    }

    public void OnDepartmentDetailViewReadyToShowEventRaised(object sender, EventArgs e)
    {
      SetUserControlVisibleInPanel((UserControl)_departmentDetailPresenter.GetDepartmentDetailViewUC());
      _mainView.ExpandUserControlPanel();
    }

    public void OnDisplayNewsBtnClickEventRaised(object sender, System.EventArgs e)
    {
      SetupNewsPageInPanel();
    }

    public void OnPlantsListBtnClickEventRaised(object sender, System.EventArgs e)
    {
      SetupPlantListInPanel();
    }

    public void OnDepartmentListBtnClickEventRaised(object sender, System.EventArgs e)
    {
      SetupDepartmentListInPanel();
    }

    private void SetupNewsPageInPanel()
    {
      _newsPresenter.LoadNewsPageIntoNewsView();

      if (_newsPresenter.ContentIsLoadedInNewsView())
      {
        SetUserControlVisibleInPanel((UserControl)_newsPresenter.GetNewsViewUC());
      }
    }
    private void SetupPlantListInPanel()
    {
      _plantListPresenter.LoadAllPlantsFromDbToGrid();
      SetUserControlVisibleInPanel((UserControl)_plantListPresenter.GetPlantListViewUC());
    }

    private void SetupDepartmentListInPanel()
    {
      _departmentListPresenter.LoadAllDepartmentsFromDbToGrid();
      SetUserControlVisibleInPanel((UserControl)_departmentListPresenter.GetDepartmentListViewUC());
    }

    public void OnUpdateSelectedDepartmentInGridMenuClickEventRaised(object sender, EventArgs e)
    {
      this._departmentListPresenter.OnUpdateSelectedDepartmentInGridMenuClickEventRaised(sender, e);
    }

    private void AssignUserControlToMainViewPanel(BaseUserControUC baseUserControl)
    {
      baseUserControl.SetParentSizeLocationAnchor(_userControlPanel);
    }

    private void SetUserControlVisibleInPanel(UserControl userControl)
    {
      foreach(UserControl uc in _userControList)
      {
        if (uc.Name == userControl.Name)
        {
          userControl.Visible = true;
        }
        else uc.Visible = false;
      }
    }

  }
}
