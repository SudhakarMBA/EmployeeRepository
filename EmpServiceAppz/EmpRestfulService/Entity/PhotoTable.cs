//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmpRestfulService.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhotoTable
    {
        public long PhotoId { get; set; }
        public long EmployeeId { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual EmployeeTable EmployeeTable { get; set; }
    }
}