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
    
    public partial class EmployeeTerminal
    {
        public EmployeeTerminal()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int TerminalID { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string Model { get; set; }
        public Nullable<int> Port { get; set; }
        public Nullable<int> MachineID { get; set; }
        public Nullable<int> Password { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
