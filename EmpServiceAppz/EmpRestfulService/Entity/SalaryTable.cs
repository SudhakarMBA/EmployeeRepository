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
    
    public partial class SalaryTable
    {
        public long SalaryId { get; set; }
        public long EmployeeId { get; set; }
        public double Salary { get; set; }
    
        public virtual EmployeeTable EmployeeTable { get; set; }
    }
}
