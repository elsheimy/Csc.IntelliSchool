﻿using Csc.Components.Common;
using Csc.IntelliSchool.Business;
using Csc.IntelliSchool.Data;
using Csc.Wpf;
using Csc.Wpf.Data;
using System;
using System.Windows;

namespace Csc.IntelliSchool.Modules.HRModule.Views.Lookup {
  public partial class ShiftOverrideTypeModifyWindow : Csc.Wpf.WindowBase {
    // Fields
    private EmployeeShiftOverrideType _item;

    // Properties
    public EmployeeShiftOverrideType Item { get { return _item; } protected set { _item = value; OnPropertyChanged(() => Item); } }
    public EmployeeShiftOverrideType OriginalItem { get; set; }

    // Constructors
    public ShiftOverrideTypeModifyWindow() {
      InitializeComponent();
      Item = new EmployeeShiftOverrideType();

    }
    public ShiftOverrideTypeModifyWindow(EmployeeShiftOverrideType item)
      : this() {
      if (item != null) {
        OriginalItem = item;
        Item = item.Clone();
      }
    }

    #region Loading
    private void WindowBase_Loaded(object sender, RoutedEventArgs e) {
      this.DeleteButton.Visibility = Item.TypeID == 0 ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;

      this.Header = Item.TypeID == 0 ? Csc.IntelliSchool.Assets.Resources.Text.Text_NewItem : Csc.IntelliSchool.Assets.Resources.Text.Text_UpdateItem;
      this.NameTextBox.Focus();
    }
    #endregion

    #region Basic
    private void CancelButton_Click(object sender, RoutedEventArgs e) { this.Close(OperationResult.None); }
    #endregion

    #region Delete
    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
      this.Confirm(Csc.IntelliSchool.Assets.Resources.HumanResources.Confirm_DeleteType, () => {
        this.SetBusy();
        EmployeesDataManager.DeleteShiftOverrideType(Item, OnDeleteCompleted);
      });
    }



    private void OnDeleteCompleted(EmployeeShiftOverrideType result, Exception error) {
      if (error == null) {
        this.Close(OperationResult.Delete);
      } else
        this.AlertError(error);
      this.ClearBusy();
    }
    #endregion

    #region Saving
    private void SaveButton_Click(object sender, RoutedEventArgs e) {
      if (this.Validate(true) == false)
        return;

      Item.TrimStrings();

      this.SetBusy();
      if (Item.TypeID == 0)
        EmployeesDataManager.AddOrUpdateShiftOverrideType(Item, OnAdded);
      else {
        EmployeesDataManager.AddOrUpdateShiftOverrideType(Item, OnUpdated);
      }
    }

    private void OnAdded(EmployeeShiftOverrideType result, Exception error) {
      if (error == null) {
        Item = result;
        this.Close(OperationResult.Add);
      } else
        this.AlertError(error);
      this.ClearBusy();
    }
    private void OnUpdated(EmployeeShiftOverrideType result, Exception error) {
      if (error == null) {
        Item = result;
        this.Close(OperationResult.Update);
      } else
        this.AlertError(error);
      this.ClearBusy();
    }
    #endregion
  }

}