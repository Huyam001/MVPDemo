/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using PresentationLayer.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
  public partial class UserInfoView : Form
  {
    MainView _parentWindow;
    public UserInfoView()
    {
      InitializeComponent();
    }
    public UserInfoView(MainView parentWindow)
    {
      InitializeComponent();
      _parentWindow = parentWindow;
    }

    private void UserInfoView_Load(object sender, EventArgs e)
    {
      //userNameLabel.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
      userNameLabel.Text = System.Windows.Forms.SystemInformation.UserName;
      //userNameLabel.Text = UserPrincipal.Current.DisplayName;

      FormHelper.SetDialogAppearance(this);

      Panel topInfoPanel = _parentWindow.GetOptionsPanel();

      this.Location = PointToScreen(_parentWindow.Location);

      PictureBox userInfoPictureBox = _parentWindow.GetUserInfoPictureBox();

      int userInfoPIctureBox_XPos = _parentWindow.Location.X + userInfoPictureBox.Location.X - this.Size.Width;

      int widthAdjustment = 
        _parentWindow.Width + (SystemInformation.Border3DSize).Width - (this.Width - SystemInformation.SizingBorderWidth);

      userInfoPIctureBox_XPos += widthAdjustment;

      int userInfoPIctureBox_YPos = 
        _parentWindow.Location.Y + topInfoPanel.Height + userInfoPictureBox.Height - (SystemInformation.Border3DSize).Width;

      this.Location = new Point(userInfoPIctureBox_XPos, userInfoPIctureBox_YPos);

    }


  }
}
