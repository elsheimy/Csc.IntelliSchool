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
    
    public partial class department
    {
        public department()
        {
            this.employee_data = new HashSet<employee_data>();
        }
    
        public int department_id { get; set; }
        public int sector_id { get; set; }
        public int department_code { get; set; }
        public string department_name { get; set; }
        public int department_number { get; set; }
    
        public virtual ICollection<employee_data> employee_data { get; set; }
    }
}
