﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NewEntities : DbContext
    {
        public NewEntities()
            : base("name=NewEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<EmployeeBranch> EmployeeBranches { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<EmployeeTerminal> EmployeeTerminals { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactNumber> ContactNumbers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLoanInstallment> EmployeeLoanInstallments { get; set; }
        public DbSet<EmployeeDeduction> EmployeeDeductions { get; set; }
        public DbSet<EmployeeLoan> EmployeeLoans { get; set; }
        public DbSet<EmployeeTerminalTransaction> EmployeeTerminalTransactions { get; set; }
        public DbSet<EmployeeTransactionRule> EmployeeTransactionRules { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        public DbSet<EmployeeBonus> EmployeeBonuses { get; set; }
        public DbSet<EmployeeEarning> EmployeeEarnings { get; set; }
        public DbSet<EmployeeSalaryUpdate> EmployeeSalaryUpdates { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<ContactEmail> ContactEmails { get; set; }
        public DbSet<EmployeeBankAccount> EmployeeBankAccounts { get; set; }
        public DbSet<EmployeeCustody> EmployeeCustodies { get; set; }
        public DbSet<EmployeeCustodyItem> EmployeeCustodyItems { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<EmployeeList> EmployeeLists { get; set; }
        public DbSet<EmployeeMedicalConcession> EmployeeMedicalConcessions { get; set; }
        public DbSet<EmployeeMedicalProgram> EmployeeMedicalPrograms { get; set; }
        public DbSet<EmployeeMedicalProvider> EmployeeMedicalProviders { get; set; }
        public DbSet<EmployeeMedicalRate> EmployeeMedicalRates { get; set; }
        public DbSet<EmployeeSocialInsurance> EmployeeSocialInsurances { get; set; }
        public DbSet<EmployeeVacation> EmployeeVacations { get; set; }
        public DbSet<SystemFlag> SystemFlags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserView> UserViews { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<EmployeeMedicalCertificate> EmployeeMedicalCertificates { get; set; }
        public DbSet<EmployeeDependant> EmployeeDependants { get; set; }
        public DbSet<ContactReference> ContactReferences { get; set; }
        public DbSet<EmployeeDepartmentList> EmployeeDepartmentLists { get; set; }
        public DbSet<EmployeeMedicalClaimDocument> EmployeeMedicalClaimDocuments { get; set; }
        public DbSet<EmployeeMedicalClaim> EmployeeMedicalClaims { get; set; }
        public DbSet<EmployeeMedicalClaimType> EmployeeMedicalClaimTypes { get; set; }
        public DbSet<EmployeePositionList> EmployeePositionLists { get; set; }
        public DbSet<EmployeeAttendanceTimeOff> EmployeeAttendanceTimeOffs { get; set; }
        public DbSet<EmployeeDepartmentVacation> EmployeeDepartmentVacations { get; set; }
        public DbSet<EmployeeMedicalProgramTemplate> EmployeeMedicalProgramTemplates { get; set; }
        public DbSet<EmployeeMedicalRequestDependant> EmployeeMedicalRequestDependants { get; set; }
        public DbSet<EmployeeMedicalRequestEmployee> EmployeeMedicalRequestEmployees { get; set; }
        public DbSet<EmployeeMedicalRequest> EmployeeMedicalRequests { get; set; }
        public DbSet<EmployeeMedicalRequestType> EmployeeMedicalRequestTypes { get; set; }
        public DbSet<EmployeeOfficialDocument> EmployeeOfficialDocuments { get; set; }
        public DbSet<EmployeeOfficialDocumentType> EmployeeOfficialDocumentTypes { get; set; }
        public DbSet<EmployeeShiftOverride> EmployeeShiftOverrides { get; set; }
        public DbSet<EmployeeDepartmentOfficialDocument> EmployeeDepartmentOfficialDocuments { get; set; }
        public DbSet<SystemLogData> SystemLogDatas { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
    }
}
