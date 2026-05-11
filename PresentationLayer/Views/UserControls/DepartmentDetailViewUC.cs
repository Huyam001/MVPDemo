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
using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
  public partial class DepartmentDetailViewUC : BaseUserControUC, IDepartmentDetailViewUC
  {
    private AccessTypeEventArgs _accessTypeEventArgs;

    public event EventHandler<AccessTypeEventArgs> DepartmentDetailSaveBtnClickEventRaised;
    public event EventHandler DepartmentDetailCancelBtnClickEventRaised;

    public AccessTypeEventArgs AccessTypeEventArgs
    {
      get { return _accessTypeEventArgs; }
      set
      {
        if (value == _accessTypeEventArgs) return;
        _accessTypeEventArgs = value;
      }
    }

    public DepartmentDetailViewUC()
    {
      InitializeComponent();

      _accessTypeEventArgs = new AccessTypeEventArgs();
    }

    public void SetUpDepartmentDetailView(Dictionary<string, Binding> bindingDictionary, 
                                          AccessTypeEventArgs accessTypeEventArgs)
    {
      BindDepartmentModelToView(bindingDictionary);
      _accessTypeEventArgs = accessTypeEventArgs;
    }

    public void BindDepartmentModelToView(Dictionary<string, Binding> bindingDictionary)
    {
      ClearExistingBindings();
      IdTextInputUC.InputBoxDataBindings.Add(bindingDictionary["DepartmentId"]);
      NameTextInputUC.InputBoxDataBindings.Add(bindingDictionary["DepartmentName"]);
      DepartmentUrlTextInputUC.InputBoxDataBindings.Add(bindingDictionary["DepartmentUrl"]);
      PhoneTextInputUC.InputBoxDataBindings.Add(bindingDictionary["PhoneNumber"]);
      EmailTextInputUC.InputBoxDataBindings.Add(bindingDictionary["Email"]);
      CityTextInputUC.InputBoxDataBindings.Add(bindingDictionary["CityLocation"]);
      StateTextInputUC.InputBoxDataBindings.Add(bindingDictionary["StateLocation"]);
    }


    public void ClearExistingBindings()
    {
      IdTextInputUC.InputBoxDataBindings.Clear();
      NameTextInputUC.InputBoxDataBindings.Clear();
      DepartmentUrlTextInputUC.InputBoxDataBindings.Clear();
      PhoneTextInputUC.InputBoxDataBindings.Clear();
      EmailTextInputUC.InputBoxDataBindings.Clear();
      CityTextInputUC.InputBoxDataBindings.Clear();
      StateTextInputUC.InputBoxDataBindings.Clear();

    }

    private void DepartmentDetailViewUC_Load(object sender, EventArgs e)
    {
      IdTextInputUC.InputBoxReadOnly = true;
      if (NameTextInputUC.InputBoxText == string.Empty)
      {
        IdTextInputUC.Visible = false;
      }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, DepartmentDetailSaveBtnClickEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);
    }

    private void CancelBtn_Click(object sender, EventArgs e)
    {
      EventHelpers.RaiseEvent(this, DepartmentDetailCancelBtnClickEventRaised, e);
    }
  }
}
