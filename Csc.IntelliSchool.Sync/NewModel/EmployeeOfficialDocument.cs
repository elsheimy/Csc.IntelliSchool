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
    
    public partial class EmployeeOfficialDocument
    {
        public int EmployeeID { get; set; }
        public int TypeID { get; set; }
        public bool IsCompleted { get; set; }
    
        public virtual EmployeeOfficialDocumentType EmployeeOfficialDocumentType { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
