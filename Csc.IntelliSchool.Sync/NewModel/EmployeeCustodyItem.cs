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
    
    public partial class EmployeeCustodyItem
    {
        public EmployeeCustodyItem()
        {
            this.EmployeeCustodies = new HashSet<EmployeeCustody>();
        }
    
        public int ItemID { get; set; }
        public int Qty { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    
        public virtual ICollection<EmployeeCustody> EmployeeCustodies { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
