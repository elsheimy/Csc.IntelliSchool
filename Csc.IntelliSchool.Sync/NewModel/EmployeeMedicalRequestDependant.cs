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
    
    public partial class EmployeeMedicalRequestDependant
    {
        public int RequestID { get; set; }
        public int DependantID { get; set; }
        public string CertificateCode { get; set; }
    
        public virtual EmployeeDependant EmployeeDependant { get; set; }
        public virtual EmployeeMedicalRequest EmployeeMedicalRequest { get; set; }
    }
}
