﻿using Csc.IntelliSchool.Data;
using Csc.IntelliSchool.Business;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using Csc.Wpf;
using Csc.Components.Common;
using Csc.Wpf.Data;

namespace Csc.IntelliSchool.Modules.PeopleModule.Views.Lookup {
  public partial class NationalitiesPage : Csc.Wpf.PageBase {
    #region Fields
    private ObservableCollection<Nationality> _items;
    #endregion


    #region Properties
    public ObservableCollection<Nationality> Items { get { return _items; } set { _items = value; OnPropertyChanged(() => Items); } }
    #endregion


    // Constructors
    public NationalitiesPage() {
      InitializeComponent();

    }

    #region Loading
    private void PageBase_Loaded(object sender, RoutedEventArgs e) { OnLoadData(); }
    private void ReloadButton_Click(object sender, RoutedEventArgs e) { OnLoadData(); }

    private void OnLoadData() {
      this.SetBusy();
      PeopleDataManager.GetNationalities(true, OnDataLoaded);
    }
    private void OnDataLoaded(Nationality[] result, Exception error) {
      if (error == null)
        Items = new ObservableCollection<Nationality>(result);
      else
        Popup.AlertError(error);

      this.ClearBusy();
    }

    private void ItemsGridView_DataLoaded(object sender, EventArgs e) {
      this.ItemsGridView.ExpandAllGroups();
    }
    #endregion

    #region Edit
    private void ItemsGridView_RowActivated(object sender, Telerik.Windows.Controls.GridView.RowEventArgs e) { OnEditItem(); }
    private void EditButton_Click(object sender, RoutedEventArgs e) { e.SelectParentRow(); OnEditItem(); }
    private void EditMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e) { OnEditItem(); }

    private void OnEditItem() {
      NationalityModifyWindow wnd = new NationalityModifyWindow((Nationality)this.ItemsGridView.SelectedItem);
      wnd.Closed += ModifyWindow_Closed;
      this.DisplayModal(wnd);
    }
    #endregion

    #region Delete
    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
      e.SelectParentRow();
      OnDeleteItem();
    }

    private void DeleteMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e) {
      OnDeleteItem();
    }

    private void OnDeleteItem() {
      Popup.ConfirmDelete(null, () => {
        this.SetBusy();
        PeopleDataManager.DeleteNationality((Nationality)this.ItemsGridView.SelectedItem, OnDeleted);
      });
    }


    private void OnDeleted(Nationality result, Exception error) {
      if (error == null)
        Items.Remove(result);
      else
        Popup.AlertError(error);
      this.ClearBusy();
    }
    #endregion

    #region Add
    private void NewMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e) {
      OnNewItem();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e) {
      OnNewItem();
    }

    private void OnNewItem() {
      NationalityModifyWindow wnd = new NationalityModifyWindow();
      wnd.Closed += ModifyWindow_Closed;
      this.DisplayModal(wnd);
    }

    void ModifyWindow_Closed(object sender, Telerik.Windows.Controls.WindowClosedEventArgs e) {
      if (e.DialogResult != true)
        return;

      var wnd = ((NationalityModifyWindow)sender);
      if (wnd.Result == OperationResult.Add) {
        Items.Add(wnd.Item);
        this.ItemsGridView.SelectItem(wnd.Item);
      } else if (wnd.Result == OperationResult.Delete)
        Items.Remove(wnd.Item);
      else if (wnd.Result == OperationResult.Update) {
        Items.Remove(wnd.OriginalItem);
        Items.Add(wnd.Item);
        this.ItemsGridView.SelectItem(wnd.Item);
      };
    }
    #endregion

    #region ContextMenu
    private void ItemsContextMenu_Opening(object sender, Telerik.Windows.RadRoutedEventArgs e) {
      var menu = sender as Telerik.Windows.Controls.RadContextMenu;
      var row = menu.GetClickedRow();

      row?.FocusSelect();


      menu.FindMenuItem("EditMenuItem").IsEnabled = this.ItemsGridView.SelectedItem != null;
      menu.FindMenuItem("DeleteMenuItem").IsEnabled = this.ItemsGridView.SelectedItem != null;
    }
    private void ReloadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e) { OnLoadData(); }

    private void MenuButton_Click(object sender, RoutedEventArgs e) {
      e.SelectParentRow();
      (sender as FrameworkElement).OpenContextMenu();
    }



    #endregion
  }
}
