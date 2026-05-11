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
using PresentationLayer.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
  public partial class MainView : Form, IMainView
  {    
    public event EventHandler MainViewLoadedEventRaised;
    public event EventHandler NewsBtnClickEventRaised;
    public event EventHandler PlantsListBtnClickEventRaised;
    public event EventHandler DepartmentListBtnClickEventRaised;
    public event EventHandler HelpAboutMenuClickEventRaised;

    private Point _userControlPanelMovingLocation;
    private int _userControlPanelTimerLoopCount             = 0;
    private const int _userControlPanelStretchIncrement     = 55;
    private const int _userControlPanelEndingStretchTopYPos = 60;

    private Panel _userControlPanelOrigValues = null;

    private List<Button> NavigationButtonList = null;

    public MainView()
    {
      InitializeComponent();
    }

    public PictureBox GetUserInfoPictureBox()
    {
      return userInfoPictureBox;
    }

    public Panel GetOptionsPanel()
    {
      return optionsPanel;
    }

    public void ResetUserControlPanelSizeandLocation()
    {
      userControlPanel.Height   = _userControlPanelOrigValues.Height;
      userControlPanel.Width    = _userControlPanelOrigValues.Width;
      userControlPanel.Location = _userControlPanelOrigValues.Location;
      SetVisibilityOfControlsForPanelSliding(true);
    }
    public void ShowMainView()
    {
      this.Show();
    }

    public void ExpandUserControlPanel()
    {
      SetVisibilityOfControlsForPanelSliding(false);

      DepartmentDetailTimer.Enabled = true;
    }
    public Panel GetUserControlPanel()
    {
      return userControlPanel;
    }

    private void SetVisibilityOfControlsForPanelSliding(bool visibility)
    {
      ButtonHelper.SetVisibilityOfButtons(NavigationButtonList, visibility, underlineLabel);

      gardenPictureBox.Visible = visibility;
    }
    private void MainView_Load(object sender, EventArgs e)
    {
      NavigationButtonList = new List<Button>() { departmentsBtn, plantsBtn, newsBtn };

      ButtonHelper.SetGroupToBorderless(NavigationButtonList);

      PictureBoxHelper.SetClickableBehavior(moreOptionsPictureBox);
      PictureBoxHelper.SetClickableBehavior(userInfoPictureBox);
      PictureBoxHelper.SetClickableBehavior(notificationBellPictureBox);

      _userControlPanelOrigValues = new Panel();

      _userControlPanelOrigValues.Height   = userControlPanel.Height;
      _userControlPanelOrigValues.Width    = userControlPanel.Width;
      _userControlPanelOrigValues.Location = new Point(userControlPanel.Location.X, userControlPanel.Location.Y);

      ButtonHelper.SetUnderlinePosition(newsBtn, underlineLabel);

      FormHelper.SetFormAppearance(this);

      EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: MainViewLoadedEventRaised, eventArgs: e);
     }

    private void PlantsBtn_Click(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: PlantsListBtnClickEventRaised, eventArgs: e);

      ButtonHelper.SetUnderlinePosition(plantsBtn, underlineLabel);
    }

    private void NewsBtn_Click(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: NewsBtnClickEventRaised, eventArgs: e);

      ButtonHelper.SetUnderlinePosition(newsBtn, underlineLabel);
    }

    private void DepartmentsBtn_Click(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, DepartmentListBtnClickEventRaised, e);

      ButtonHelper.SetUnderlinePosition(departmentsBtn, underlineLabel);
    }

    private void userPictureBox_Click(object sender, EventArgs e)
    {
      UserInfoView userInfoView = new UserInfoView(this);
      
      userInfoView.ShowDialog();
    }

    private void departmentDetailTimer_Tick(object sender, EventArgs e)
    {
      if (_userControlPanelTimerLoopCount == 0)
      {
        _userControlPanelTimerLoopCount++;
        userControlPanel.Location = new Point(5, this.Height);

        _userControlPanelMovingLocation = new Point(_userControlPanelOrigValues.Location.X, _userControlPanelOrigValues.Location.Y);
      }

      if (_userControlPanelMovingLocation.Y > _userControlPanelEndingStretchTopYPos)
      {
        _userControlPanelMovingLocation.Y = _userControlPanelMovingLocation.Y - _userControlPanelStretchIncrement;
        userControlPanel.Location         = _userControlPanelMovingLocation;
        userControlPanel.Height          += _userControlPanelStretchIncrement;
      }
      else
      {
        _userControlPanelTimerLoopCount = 0;
        DepartmentDetailTimer.Enabled   = false;
      }
    }

    private void moreOptionsPictureBox_Click(object sender, EventArgs e)
    {
      PictureBoxHelper.DisplayContextMenu(moreOptionsPictureBox, moreOptionsContextMenuStrip, this);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, HelpAboutMenuClickEventRaised, e);
    }





  }
}
