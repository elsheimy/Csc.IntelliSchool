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
    
    public partial class Employee
    {
        public Employee()
        {
            this.Deductions = new HashSet<EmployeeDeduction>();
            this.Loans = new HashSet<EmployeeLoan>();
            this.Attendance = new HashSet<EmployeeAttendance>();
            this.Bonuses = new HashSet<EmployeeBonus>();
            this.Earnings = new HashSet<EmployeeEarning>();
            this.SalaryUpdates = new HashSet<EmployeeSalaryUpdate>();
            this.EmployeeCustodies = new HashSet<EmployeeCustody>();
            this.EmployeeCustodyItems = new HashSet<EmployeeCustodyItem>();
            this.EmployeeDocuments = new HashSet<EmployeeDocument>();
            this.Vacations = new HashSet<EmployeeVacation>();
            this.Dependants = new HashSet<EmployeeDependant>();
            this.EmployeeMedicalRequestEmployees = new HashSet<EmployeeMedicalRequestEmployee>();
            this.EmployeeOfficialDocuments = new HashSet<EmployeeOfficialDocument>();
        }
    
        public int EmployeeID { get; set; }
        public Nullable<int> LocalID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FamilyName { get; set; }
        public string ArabicFirstName { get; set; }
        public string ArabicMiddleName { get; set; }
        public string ArabicLastName { get; set; }
        public string ArabicFamilyName { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birthdate { get; set; }
        public string IDNumber { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<int> ReligionID { get; set; }
        public Nullable<int> BranchID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<int> ShiftID { get; set; }
        public Nullable<int> TerminalID { get; set; }
        public Nullable<int> TerminalUserID { get; set; }
        public Nullable<int> ContactID { get; set; }
        public System.DateTime HireDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public string TerminationReason { get; set; }
        public Nullable<int> ListID { get; set; }
        public bool IsCustody { get; set; }
        public string PhotoUrl { get; set; }
        public Nullable<int> MedicalCertificateID { get; set; }
        public Nullable<bool> TerminationHide { get; set; }
    
        public virtual Contact Contact { get; set; }
        public virtual EmployeeBranch Branch { get; set; }
        public virtual EmployeeDepartment Department { get; set; }
        public virtual EmployeePosition Position { get; set; }
        public virtual EmployeeShift Shift { get; set; }
        public virtual EmployeeTerminal Terminal { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual EmployeeSalary Salary { get; set; }
        public virtual ICollection<EmployeeDeduction> Deductions { get; set; }
        public virtual ICollection<EmployeeLoan> Loans { get; set; }
        public virtual ICollection<EmployeeAttendance> Attendance { get; set; }
        public virtual ICollection<EmployeeBonus> Bonuses { get; set; }
        public virtual ICollection<EmployeeEarning> Earnings { get; set; }
        public virtual ICollection<EmployeeSalaryUpdate> SalaryUpdates { get; set; }
        public virtual EmployeeBankAccount EmployeeBankAccount { get; set; }
        public virtual ICollection<EmployeeCustody> EmployeeCustodies { get; set; }
        public virtual ICollection<EmployeeCustodyItem> EmployeeCustodyItems { get; set; }
        public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
        public virtual EmployeeList List { get; set; }
        public virtual EmployeeSocialInsurance SocialInsurance { get; set; }
        public virtual ICollection<EmployeeVacation> Vacations { get; set; }
        public virtual EmployeeMedicalCertificate MedicalCertificate { get; set; }
        public virtual ICollection<EmployeeDependant> Dependants { get; set; }
        public virtual ICollection<EmployeeMedicalRequestEmployee> EmployeeMedicalRequestEmployees { get; set; }
        public virtual ICollection<EmployeeOfficialDocument> EmployeeOfficialDocuments { get; set; }
    }
}
