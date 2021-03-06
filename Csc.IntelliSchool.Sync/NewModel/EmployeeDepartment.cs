//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Csc.IntelliSchool.Sync.NewModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeDepartment
    {
        public EmployeeDepartment()
        {
            this.Employees = new HashSet<Employee>();
            this.EmployeeDepartmentLists = new HashSet<EmployeeDepartmentList>();
            this.EmployeeDepartmentVacations = new HashSet<EmployeeDepartmentVacation>();
            this.EmployeeDepartmentOfficialDocuments = new HashSet<EmployeeDepartmentOfficialDocument>();
        }
    
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<EmployeeDepartmentList> EmployeeDepartmentLists { get; set; }
        public virtual ICollection<EmployeeDepartmentVacation> EmployeeDepartmentVacations { get; set; }
        public virtual ICollection<EmployeeDepartmentOfficialDocument> EmployeeDepartmentOfficialDocuments { get; set; }
    }
}
