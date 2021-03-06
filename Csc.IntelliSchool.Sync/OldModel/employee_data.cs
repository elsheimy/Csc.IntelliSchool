//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Csc.IntelliSchool.Sync.OldModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee_data
    {
        public int employee_id { get; set; }
        public string terminal_ip { get; set; }
        public int user_id { get; set; }
        public string employee_name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int salary { get; set; }
        public System.DateTime employee_bd { get; set; }
        public string employee_nationality { get; set; }
        public string employee_gender { get; set; }
        public string employee_mstatus { get; set; }
        public string employee_phone { get; set; }
        public string employee_add { get; set; }
        public System.DateTime employee_working_date { get; set; }
        public int vacations { get; set; }
        public int sector_id { get; set; }
        public int department_id { get; set; }
        public int type_id { get; set; }
        public int status_id { get; set; }
        public int shift_id { get; set; }
        public string category { get; set; }
        public int insurance { get; set; }
        public int tax { get; set; }
        public int housing { get; set; }
        public int ticket { get; set; }
        public int settelement { get; set; }
        public int loan { get; set; }
        public int atm { get; set; }
        public int we_exception { get; set; }
        public int points_exception { get; set; }
        public bool ex_employee { get; set; }
        public int fp_exception { get; set; }
        public int enc_salary { get; set; }
        public int teacher_lock { get; set; }
        public Nullable<bool> IsAttendanceHidden { get; set; }
        public string SuggestedInsuranceProgram { get; set; }
        public string Group { get; set; }
        public string InsuranceProgram { get; set; }
        public Nullable<int> InsuranceRate { get; set; }
        public Nullable<decimal> InsuranceConcession { get; set; }
        public Nullable<int> InsuranceMonthly { get; set; }
        public string IDNumber { get; set; }
        public Nullable<int> RefID { get; set; }
        public string RefType { get; set; }
        public Nullable<System.DateTime> InsuranceActiveDate { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }
    
        public virtual department department { get; set; }
        public virtual employee_types employee_types { get; set; }
    }
}
