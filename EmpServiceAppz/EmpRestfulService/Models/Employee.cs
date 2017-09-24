using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpRestfulService.Models
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public long EmployeePhoneNo { get; set; }
        public string EmployeeEmail { get; set; }
        public bool IsActive { get; set; }
    }
}