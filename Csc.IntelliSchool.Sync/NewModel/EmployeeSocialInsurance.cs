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
    
    public partial class EmployeeSocialInsurance
    {
        public int EmployeeID { get; set; }
        public string SocialID { get; set; }
        public System.DateTime EnrollmentDate { get; set; }
        public Nullable<System.DateTime> CancellationDate { get; set; }
        public int Basic { get; set; }
        public int Allowance { get; set; }
        public decimal Emergency { get; set; }
        public decimal Services { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
