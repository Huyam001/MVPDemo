/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Common
{
  static public class ButtonHelper
  {
    static public void SetToBorderless(Button button )
    {
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.MouseOverBackColor = button.BackColor;
        button.FlatAppearance.MouseDownBackColor = button.BackColor;

      button.MouseMove += new MouseEventHandler(OnBorderlessMouseMoveEventRaised);
      button.MouseLeave += new EventHandler(OnBorderlessMouseLeaveEventRaised);
    }

    static public void SetGroupToBorderless(List<Button> buttons)
    {
      foreach(Button btn in buttons)
      {
        SetToBorderless(btn);
      }
    }

    static private void OnBorderlessMouseMoveEventRaised(object sender, MouseEventArgs e)
    {
      Cursor.Current = Cursors.Hand;
    }
    static private void OnBorderlessMouseLeaveEventRaised(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.Default;
    }

     static public void SetVisibilityOfButtons(List<Button> buttons, bool visibility, Label underlineLabel)
    {
      foreach (Button btn in buttons)
      {
        btn.Visible = visibility;
      }

      if (underlineLabel != null)
      {
        underlineLabel.Visible = visibility;
      }
    }

     static public  void SetUnderlinePosition(Button button, Label underlineLabel)
    {
      underlineLabel.Width = button.Bounds.Width - (int)(button.Bounds.Width * .15); ;
      underlineLabel.Left = button.Bounds.Left + (int)(button.Bounds.Width * .08); ;
      underlineLabel.Top = button.Top + button.Height;
    }


  }
}
