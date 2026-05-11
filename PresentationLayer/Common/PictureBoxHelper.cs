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
using System.Drawing;
using System.Windows.Forms;


namespace PresentationLayer.Common
{
  static public class PictureBoxHelper
  {
    static public void SetClickableBehavior(PictureBox pictureBox)
    {
      pictureBox.MouseMove += new MouseEventHandler(OnPictureBoxMouseMoveEventRaised);
      pictureBox.MouseLeave += new EventHandler(OnPictureBoxMouseLeaveEventRaised);
    }
    static private void OnPictureBoxMouseMoveEventRaised(object sender, MouseEventArgs e)
    {
      Cursor.Current = Cursors.Hand;
    }
    static private void OnPictureBoxMouseLeaveEventRaised(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.Default;
    }


    static public void DisplayContextMenu(PictureBox pictureBox, ContextMenuStrip contextMenuStrip, Form form)
    {
      Point pointForContextMenu = form.PointToScreen(
        new Point(pictureBox.Location.X - contextMenuStrip.Width + pictureBox.Width,
                  pictureBox.Location.Y + pictureBox.Height));

      contextMenuStrip.Show(pointForContextMenu.X, pointForContextMenu.Y);
    }


  }
}
