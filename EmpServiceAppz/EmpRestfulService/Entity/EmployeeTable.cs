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
    
    public partial class EmployeeTable
    {
        public EmployeeTable()
        {
            this.PhotoTables = new HashSet<PhotoTable>();
            this.SalaryTables = new HashSet<SalaryTable>();
        }
    
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public long EmployeePhoneNo { get; set; }
        public string EmployeeEmail { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<PhotoTable> PhotoTables { get; set; }
        public virtual ICollection<SalaryTable> SalaryTables { get; set; }
    }
}
