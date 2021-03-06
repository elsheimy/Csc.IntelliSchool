using System;
using System.IO;
using System.Linq;
using Csc.Components.Common;
using Csc.IntelliSchool.Data;
using System.Collections.Generic;

namespace Csc.IntelliSchool.Service {
  public partial class EmployeesService {
    #region Programs

    public EmployeeMedicalProgram[] GetEmployeeMedicalPrograms(EmployeeMedicalProgramDataFilter filter) {
      using (var ent = CreateModel()) {
        return ent.EmployeeMedicalPrograms.Query(filter).OrderBy(s => s.Provider.Name).ThenBy(s => s.Name).ToArray();
      }
    }
    #endregion

    #region Employees
    /// <summary>
    /// Returns registered / can-be-registered employees
    /// </summary>
    /// <returns></returns>
    public Employee[] GetApplicableMedicalEmployees(EmployeeIncludes filter) { return InternalGetMedicalEmployees(filter, null, false); }
    public Employee[] GetCoveredMedicalEmployees(EmployeeIncludes filter) { return InternalGetMedicalEmployees(filter, null, true); }
    private static Employee[] InternalGetMedicalEmployees(EmployeeIncludes filter, int[] employeeIds, bool coveredOnly) {
      using (var ent = CreateModel()) {
        var qry = ent.Employees.Query(filter, new EmployeeDataCriteria() { EmployeeIDs = employeeIds });

        DateTime startDate = DateTime.Today.ToMonth();
        DateTime endDate = startDate.ToMonthEnd();

        if (coveredOnly)
          qry = qry.Where(s => s.MedicalCertificate != null || s.Dependants.Where(x => x.MedicalCertificate != null).Count() > 0);
        else
          qry = qry.Where(s =>
            (s.HireDate <= endDate && (s.TerminationDate == null || s.TerminationDate >= startDate))
            || s.MedicalCertificate != null
            || s.Dependants.Where(x => x.MedicalCertificate != null).Count() > 0);

        return qry.ToArray();
      }
    }

    #endregion


    #region Salaries
    public Employee[] ApplyEmployeeMedicalSalaries(int[] employeeIds, bool applySalaries, DateTime? applyMonth) {
      applyMonth = applyMonth.ToMonth();
      using (var ent = CreateModel()) {
        Employee[] employees = ent.Employees.Query(EmployeeIncludes.Salary | EmployeeIncludes.Medical | EmployeeIncludes.Dependants,
          new EmployeeDataCriteria() { EmployeeIDs = employeeIds} ).ToArray();

        EmployeeEarning[] earnings = null;
        if (applyMonth != null)
          earnings = ent.EmployeeEarnings.Where(s => employeeIds.Contains(s.EmployeeID) && s.Month == applyMonth.Value).ToArray();

        foreach (var emp in employees) {
          if (applySalaries && emp.Salary.Medical != (emp.MedicalInfo.ActiveMonthlyTotal ?? 0)) {
            emp.Salary.Medical = emp.MedicalInfo.ActiveMonthlyTotal ?? 0;

            emp.SalaryUpdates.Add(new EmployeeSalaryUpdate() {
              Salary = emp.Salary.Salary,
              Social = emp.Salary.Social,
              Medical = emp.Salary.Medical,
              Taxes = emp.Salary.Taxes,
            });
          }
          if (applyMonth != null) {
            var earn = earnings.SingleOrDefault(s => s.EmployeeID == emp.EmployeeID);
            if (earn != null)
              earn.Medical = emp.MedicalInfo.ActiveMonthlyTotal ?? 0;
          }
        }

        ent.Logger.LogDatabase(CurrentUser, SystemLogDataAction.ApplyMedical, typeof(Employee), employees.Select(s => s.EmployeeID).ToArray());

        ent.SaveChanges();

        return employees;
      }
    }


    #endregion

    

    #region Templates


    public EmployeeMedicalProgramTemplate GetMedicalProgramTemplate(EmployeeMedicalRequest req) {
      using (var ent = CreateModel()) {
        return ent.EmployeeMedicalProgramTemplates.SingleOrDefault(s => s.ProgramID == req.ProgramID && s.TypeID == req.TypeID);
      }
    }

    public Stream GenerateEmployeeMedicalRequest(EmployeeMedicalRequest req) {
      return null;


      //EmployeeMedicalProgram program = null;
      //var items = req.GetRequestItems();

      //using (ExcelProcessor proc = new ExcelProcessor()) {

      //  using (var ent = CreateModel()) {
      //    program = ent.EmployeeMedicalPrograms.Single(s => s.ProgramID == req.ProgramID);
      //    proc.LoadFile(
      //      AppPath.FormatPath(AppPathSection.HumanResourcesMedicalTemplates,
      //      ent.EmployeeMedicalProgramTemplates.Single(s => s.ProgramID == req.ProgramID && s.TypeID == req.TypeID).Path));
      //  }

      //  // find range
      //  var range = proc.FindRange(new TemplateParam(MedicalRequestParam.RangeStart.ToString()), new TemplateParam(MedicalRequestParam.RangeEnd.ToString()));

      //  if (range != null) {
      //    List<TemplateParamCollection> rowInputs = new List<TemplateParamCollection>();
      //    foreach (var itm in items) {
      //      TemplateParamCollection lst = new TemplateParamCollection();
      //      lst.Add(new TemplateParam(MedicalRequestParam.TypeShort.ToString(), itm.Type != null && itm.Type.Length > 0 ? itm.Type.Substring(0, 1) : string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.Type.ToString(), itm.Type ?? string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.CertNumber.ToString(), itm.CertificateCode ?? string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.FirstName.ToString(), itm.FirstName ?? string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.MiddleName.ToString(), itm.MiddleName ?? string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.LastName.ToString(), itm.LastName ?? string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.FullName.ToString(), new string[] { itm.FirstName, itm.MiddleName, itm.LastName }.Combine()));
      //      lst.Add(new TemplateParam(MedicalRequestParam.Birthdate.ToString(), itm.Birthdate.ToString("dd/MM/yyyy")));
      //      lst.Add(new TemplateParam(MedicalRequestParam.Gender.ToString(), itm.Gender ?? string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.GenderShort.ToString(), itm.Gender != null && itm.Gender.Length > 0 ? itm.Gender.Substring(0, 1) : string.Empty));
      //      lst.Add(new TemplateParam(MedicalRequestParam.Today.ToString(), DateTime.Today.ToString("dd/MM/yyyy")));
      //      rowInputs.Add(lst);
      //    }

      //    proc.FillRange(range, rowInputs);
      //  }

      //  // change policy number
      //  proc.FindAndReplace(new TemplateParam(MedicalRequestParam.CompanyName.ToString(), AppExtensions.GetInfo().CompanyName ?? string.Empty));
      //  proc.FindAndReplace(new TemplateParam(MedicalRequestParam.PolicyNumber.ToString(), program.PolicyCode ?? string.Empty));
      //  proc.FindAndReplace(new TemplateParam(MedicalRequestParam.Today.ToString(), DateTime.Today.ToString("dd/MM/yyyy")));

      //  return proc.ExportStream();
      //}
    }
    #endregion



  }


}
