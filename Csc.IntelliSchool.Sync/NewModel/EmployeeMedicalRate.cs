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
    
    public partial class EmployeeMedicalRate
    {
        public int RateID { get; set; }
        public int ProgramID { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int DependantValue { get; set; }
        public int EmployeeValue { get; set; }
        public int CustomValue { get; set; }
    
        public virtual EmployeeMedicalProgram EmployeeMedicalProgram { get; set; }
    }
}
