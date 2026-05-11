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
using DomainLayer.Models.Department;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.DepartmentServices;
using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls
{
  public class DepartmentDetailPresenter : BasePresenter, IDepartmentDetailPresenter
  {
    public event EventHandler DepartmentDetailViewReadyToShowEventRaised;
    public event EventHandler DepartmentDetailCancelBtnClickEventRaised;
    public event EventHandler<AccessTypeEventArgs> DepartmentDetailSaveBtnClickEventRaised;


    private IDepartmentDetailViewUC _departmentDetailViewUC;
    private IDepartmentServices _departmentServices;
    private IDepartmentModel _departmentModelWithoutBinding;
    private IDepartmentModel _departmentModelOrigValuesBeforeEdit;


    private bool _isModifiedEnabled = false;
    private bool _departmentModelWasChangedInView = false;
    // Fields recreated here from DepartmentModel to be databound to the View
    private int _departmentId;
    private string _departmentName;
    private string _departmentUrl;
    private string _phoneNumber;
    private string _email;
    private string _cityLocation;
    private string _stateLocation;


     public IDepartmentDetailViewUC GetDepartmentDetailViewUC()
    {
      return _departmentDetailViewUC;
    }

    public DepartmentDetailPresenter(IDepartmentDetailViewUC departmentDetailViewUC, 
                                     IDepartmentServices departmentServices,
                                     IDepartmentModel departmentModelWithoutBinding,
                                     IDepartmentModel departmentModelOrigValuesBeforeEdit)
    {
      _departmentDetailViewUC              = departmentDetailViewUC;
      _departmentServices                  = departmentServices;
      _departmentModelWithoutBinding       = departmentModelWithoutBinding;
      _departmentModelOrigValuesBeforeEdit = departmentModelOrigValuesBeforeEdit;

      SubscribeToEventsSetup();
   }

    private void SubscribeToEventsSetup()
    {
      _departmentDetailViewUC.DepartmentDetailSaveBtnClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnDepartmentDetailSaveBtnClickEventRaised);

      _departmentDetailViewUC.DepartmentDetailCancelBtnClickEventRaised += new EventHandler(OnDepartmentDetailCancelBtnClickEventRaised);
    }

    private bool DepartmentValuesVerifiedToHaveChanged(AccessTypeEventArgs accessTypeEventArg)
    {
      bool changedValueDetected = false;

      if (accessTypeEventArg.AccessTypeValue == AccessTypeEventArgs.AccessType.Update)
      { 
        if (_departmentModelOrigValuesBeforeEdit.DepartmentName != _departmentName)
          changedValueDetected = true;
        else if (_departmentModelOrigValuesBeforeEdit.CityLocation != _cityLocation)
          changedValueDetected = true;
        else if (_departmentModelOrigValuesBeforeEdit.StateLocation != _stateLocation)
          changedValueDetected = true;
        else if (_departmentModelOrigValuesBeforeEdit.DepartmentUrl != _departmentUrl)
          changedValueDetected = true;
        else if (_departmentModelOrigValuesBeforeEdit.Email != _email)
          changedValueDetected = true;
        else if (_departmentModelOrigValuesBeforeEdit.PhoneNumber != _phoneNumber)
          changedValueDetected = true;
        }

        if (changedValueDetected == true)
        {
          accessTypeEventArg.ValuesWereChanged = true;
        }
        else
        {
          accessTypeEventArg.ValuesWereChanged = false;
        }

      return changedValueDetected;
    }

    private void OnDepartmentDetailSaveBtnClickEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
    {
      if (
           (_departmentModelWasChangedInView == true) && (DepartmentValuesVerifiedToHaveChanged(accessTypeEventArgs) ==true)
           ||
           (_departmentModelWasChangedInView == true) && (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Add)
         ) 
      {
        _departmentModelWithoutBinding.DepartmentName = _departmentName;
        _departmentModelWithoutBinding.DepartmentUrl  = _departmentUrl;
        _departmentModelWithoutBinding.CityLocation   = _cityLocation;
        _departmentModelWithoutBinding.StateLocation  = _stateLocation;
        _departmentModelWithoutBinding.DepartmentUrl  = _departmentUrl;
        _departmentModelWithoutBinding.Email          = _email;
        _departmentModelWithoutBinding.PhoneNumber    = _phoneNumber;

        try
        {
          if (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Update)
          {
            _departmentServices.Update(_departmentModelWithoutBinding); //Use model service to save updated model to database 
          }
          else
          {
            _departmentServices.Add(_departmentModelWithoutBinding); //Use model service to save updated model to database 
          }
          InitializeValues(isModifiedEnabled: false);
        }
        catch (Exception e1)
        {
          ShowErrorMessage("Error Message", e1.Message);
          return;
        }

      }
        EventHelpers.RaiseEvent(this, DepartmentDetailSaveBtnClickEventRaised, accessTypeEventArgs);        
    }

    private void OnDepartmentDetailCancelBtnClickEventRaised(object sender, EventArgs e)
    {
     EventHelpers.RaiseEvent(this, DepartmentDetailCancelBtnClickEventRaised, new EventArgs());
    }

    private void InitializeValues(bool isModifiedEnabled)
    {
      _departmentModelWasChangedInView = false;
      _isModifiedEnabled = isModifiedEnabled;

      _departmentId   = 0;
      _departmentName = string.Empty;
      _departmentUrl  = string.Empty;
      _phoneNumber    = string.Empty;
      _email          = string.Empty;
      _cityLocation   = string.Empty;
      _stateLocation  = string.Empty;

      _departmentModelWithoutBinding.DepartmentName = string.Empty;
      _departmentModelWithoutBinding.DepartmentUrl  = string.Empty;
      _departmentModelWithoutBinding.CityLocation   = string.Empty;
      _departmentModelWithoutBinding.StateLocation  = string.Empty;
      _departmentModelWithoutBinding.DepartmentUrl  = string.Empty;
      _departmentModelWithoutBinding.Email          = string.Empty;
      _departmentModelWithoutBinding.PhoneNumber    = string.Empty;

    }

    public void SetupDepartmentForAdd()
    {
      InitializeValues(isModifiedEnabled: true);

      Dictionary<string, Binding> departmentModelbindingDictionary = new Dictionary<string, Binding>();

      SetupBindingsForView(departmentModelbindingDictionary);

      AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

      accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

      _departmentDetailViewUC.SetUpDepartmentDetailView(departmentModelbindingDictionary, accessTypeEventArgs);

      EventHelpers.RaiseEvent(this, DepartmentDetailViewReadyToShowEventRaised, new EventArgs());
    }

    public void SetupDepartmentForUpdate(int departmentId)
    {
      InitializeValues(isModifiedEnabled:true);

      Dictionary<string, Binding> departmentModelbindingDictionary = new Dictionary<string, Binding>();

      LoadDepartmentToBeUpdated(departmentId);

      SetupBindingsForView(departmentModelbindingDictionary);

      AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

      accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Update;

      //Tell View to load up its DataGridView with binding objects created here
      _departmentDetailViewUC.SetUpDepartmentDetailView(departmentModelbindingDictionary, accessTypeEventArgs);

      EventHelpers.RaiseEvent(this, DepartmentDetailViewReadyToShowEventRaised, new EventArgs());
    }

    private void SetupBindingsForView(Dictionary<string, Binding> departmentModelbindingDictionary)
    {
      //Create bindings for data the View will use on its textBoxes
      Binding departmentIdNameBinding = new Binding("Text", this, "DepartmentId", false, DataSourceUpdateMode.Never);
      Binding departmentNameBinding   = new Binding("Text", this, "DepartmentName", false, DataSourceUpdateMode.OnPropertyChanged);
      Binding departmentUrlBinding    = new Binding("Text", this, "DepartmentUrl", false, DataSourceUpdateMode.OnPropertyChanged);
      Binding phoneNumberBinding      = new Binding("Text", this, "PhoneNumber", false, DataSourceUpdateMode.OnPropertyChanged);
      Binding emailBinding            = new Binding("Text", this, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
      Binding cityLocationBinding     = new Binding("Text", this, "CityLocation", false, DataSourceUpdateMode.OnPropertyChanged);
      Binding stateLocationBinding    = new Binding("Text", this, "StateLocation", false, DataSourceUpdateMode.OnPropertyChanged);

      //Store bindings into a dictionary for the View to access for its textBoxes
      departmentModelbindingDictionary.Add("DepartmentId", departmentIdNameBinding);
      departmentModelbindingDictionary.Add("DepartmentName", departmentNameBinding);
      departmentModelbindingDictionary.Add("DepartmentUrl", departmentUrlBinding);
      departmentModelbindingDictionary.Add("PhoneNumber", phoneNumberBinding);
      departmentModelbindingDictionary.Add("Email", emailBinding);
      departmentModelbindingDictionary.Add("CityLocation", cityLocationBinding);
      departmentModelbindingDictionary.Add("StateLocation", stateLocationBinding);
    }


    private void LoadDepartmentToBeUpdated(int departmentId)
    {
      _departmentModelWithoutBinding = _departmentServices.GetById(departmentId);

      _departmentId   = _departmentModelWithoutBinding.DepartmentId;
      _departmentName = _departmentModelWithoutBinding.DepartmentName;
      _departmentUrl  = _departmentModelWithoutBinding.DepartmentUrl;
      _phoneNumber    = _departmentModelWithoutBinding.PhoneNumber;
      _email          = _departmentModelWithoutBinding.Email;
      _cityLocation   = _departmentModelWithoutBinding.CityLocation;
      _stateLocation  = _departmentModelWithoutBinding.StateLocation;

      _departmentModelOrigValuesBeforeEdit.DepartmentId    =_departmentModelWithoutBinding.DepartmentId;
      _departmentModelOrigValuesBeforeEdit.DepartmentName  =_departmentModelWithoutBinding.DepartmentName;
      _departmentModelOrigValuesBeforeEdit.DepartmentUrl   =_departmentModelWithoutBinding.DepartmentUrl;
      _departmentModelOrigValuesBeforeEdit.PhoneNumber     =_departmentModelWithoutBinding.PhoneNumber;
      _departmentModelOrigValuesBeforeEdit.Email           =_departmentModelWithoutBinding.Email;
      _departmentModelOrigValuesBeforeEdit.CityLocation    =_departmentModelWithoutBinding.CityLocation;
      _departmentModelOrigValuesBeforeEdit.StateLocation   = _departmentModelWithoutBinding.StateLocation;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
      if (_isModifiedEnabled == true)
      {
        _departmentModelWasChangedInView = true;
      }
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public DepartmentModel DepartmentModel
    {
      get { return (DepartmentModel)_departmentModelWithoutBinding; }
      set
      {
        if (value == _departmentModelWithoutBinding) return;
        _departmentModelWithoutBinding = value;
        //NotifyPropertyChanged(); not to be implemented for this property
      }
    }

    public int DepartmentId
    {
      get { return this._departmentId; }
      set
      {
        if (value == this._departmentId) return;
        this._departmentId = value;
        NotifyPropertyChanged();
      }
    }

    public string DepartmentName
    {
      get { return this._departmentName; }
      set
      {
        if (value == this._departmentName) return;
        this._departmentName = value;
        NotifyPropertyChanged();
      }
    }

    public string DepartmentUrl
    {
      get { return this._departmentUrl; }
      set
      {
        if (value == this._departmentUrl) return;
        this._departmentUrl = value;
        NotifyPropertyChanged();
      }
    }

    public string PhoneNumber
    {
      get { return this._phoneNumber; }
      set
      {
        if (value == this._phoneNumber) return;
        this._phoneNumber = value;
        NotifyPropertyChanged();
      }
    }

    public string Email
    {
      get { return this._email; }
      set
      {
        if (value == this._email) return;
        this._email = value;
        NotifyPropertyChanged();
      }
    }

    public string CityLocation
    {
      get { return this._cityLocation; }
      set
      {
        if (value == this._cityLocation) return;
        this._cityLocation = value;
        NotifyPropertyChanged();
      }
    }
    public string StateLocation
    {
      get { return this._stateLocation; }
      set
      {
        if (value == this._stateLocation) return;
        this._stateLocation = value;
        NotifyPropertyChanged();
      }
    }








  }
}
