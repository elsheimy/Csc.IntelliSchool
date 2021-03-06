using System;
using System.Linq;
using Csc.Components.Common;
using Csc.IntelliSchool.Data;
using System.Collections.Generic;

namespace Csc.IntelliSchool.Service {
  public partial class EmployeesService {
    #region Terminals
    public EmployeeTerminal[] GetTerminals() {
      using (var ent = CreateModel()) {
        return ent.GetItems<EmployeeTerminal>().OrderBy(s => s.Name).ToArray();
      }
    }
    public EmployeeTerminal AddOrUpdateTerminal(EmployeeTerminal item) {
      using (var ent = CreateModel()) {
        bool isInsert = item.TerminalID == 0;

        item = ent.AddOrUpdateItem<EmployeeTerminal>(item);

        ent.Logger.LogDatabase(CurrentUser,
          isInsert ? SystemLogDataAction.Insert : SystemLogDataAction.Update, item.GetType(),
          item.TerminalID.PackArray(),
          null, null);
        ent.SaveChanges();

        return item;
      }
    }

    public void DeleteTerminal(int id) {
      using (var ent = CreateModel()) {
        ent.RemoveItem<EmployeeTerminal>(id);
      }
    }


    #endregion
  }

}

