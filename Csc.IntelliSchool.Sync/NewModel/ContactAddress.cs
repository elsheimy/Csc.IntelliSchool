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
    
    public partial class ContactAddress
    {
        public int AddressID { get; set; }
        public int ContactID { get; set; }
        public string Reference { get; set; }
        public bool IsDefault { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ArabicAddress { get; set; }
        public string ArabicCity { get; set; }
        public string ArabicState { get; set; }
        public string ArabicCountry { get; set; }
        public Nullable<decimal> LocationLatitude { get; set; }
        public Nullable<decimal> LocationLongitude { get; set; }
    
        public virtual Contact Contact { get; set; }
    }
}
