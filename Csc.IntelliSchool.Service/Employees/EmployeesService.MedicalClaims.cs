using System;
using System.IO;
using System.Linq;
using Csc.Components.Common;
using Csc.IntelliSchool.Data;
using System.Collections.Generic;

namespace Csc.IntelliSchool.Service {
  public partial class EmployeesService {
    #region Claims
    public void DeleteEmployeeMedicalClaim(int id ) {
      using (var ent = CreateModel()) {
        ent.RemoveItem<EmployeeMedicalClaim>(id);
      }
    }
    public EmployeeMedicalClaim[] GetEmployeeMedicalClaims(int[] statusIds, DateTime? startDate, DateTime? endDate) {
      startDate = startDate.ToDay();
      endDate = startDate.ToDayEnd();
      using (var ent = CreateModel()) {
        return ent.EmployeeMedicalClaims.Query( EmployeeMedicalClaimIncludes.All,
          new EmployeeMedicalClaimDataCriteria() {
            StatusIDs = statusIds, StartDate = startDate, EndDate = endDate 
          }).OrderBy(s => s.Date).ThenBy(s => s.ClaimID).ToArray();
      }
    }

    public EmployeeMedicalClaim AddOrUpdateEmployeeMedicalClaim(EmployeeMedicalClaim userItem) {
      userItem.Type = null;
      using (var ent = CreateModel()) {
        EmployeeMedicalClaim dbItem = null;
        if (userItem.ClaimID != 0)
          dbItem = ent.EmployeeMedicalClaims.SingleOrDefault(s => s.ClaimID == userItem.ClaimID);

        if (dbItem != null) { // update
          ent.Entry(dbItem).CurrentValues.SetValues(userItem);
        } else {
          ent.EmployeeMedicalClaims.Add(userItem);

          ent.SetUnchanged(userItem.Employee,
            userItem.Dependant,
            userItem.Status,
            userItem.Type);
        }

        ent.SaveChanges();

        ent.Logger.LogDatabase(CurrentUser, dbItem != null ? SystemLogDataAction.Update : SystemLogDataAction.Insert, typeof(EmployeeMedicalClaim), userItem.ClaimID.PackArray(),
          new SystemLogDataEntry() { EmployeeID = userItem.EmployeeID });
        ent.Logger.Flush();

        return ent.EmployeeMedicalClaims.Query(EmployeeMedicalClaimIncludes.All, 
          new EmployeeMedicalClaimDataCriteria() { ClaimIDs = userItem.ClaimID.PackArray() }).SingleOrDefault();
      }
    }

    public EmployeeMedicalClaimStatus[] GetMedicalClaimStatuses() {
      using (var ent = CreateModel()) {
        return ent.EmployeeMedicalClaimStatuses.ToArray();
      }
    }

    public EmployeeMedicalClaimType[] GetMedicalClaimTypes() {
      using (var ent = CreateModel()) {
        return ent.EmployeeMedicalClaimTypes.ToArray();
      }
    }
    #endregion
  }


}
