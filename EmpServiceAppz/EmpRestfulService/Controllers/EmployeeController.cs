using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EmpRestfulService.Entity;
using EmpRestfulService.Models;

namespace EmpRestfulService.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : ApiController
    {
        [HttpPost]
        [Route("SaveEmployee")]
        public IHttpActionResult SaveEmployee(Employee employee)
        {
            EmpDbEntities entity = new EmpDbEntities();
            EmployeeTable exist = entity.EmployeeTables.Where(d => d.EmployeeName == employee.EmployeeName).FirstOrDefault();
            if (exist != null)
            {
                throw new Exception("Record is already exist");
            }
            EmployeeTable table = new EmployeeTable();
            table.EmployeeName = employee.EmployeeName;
            table.EmployeeAddress = employee.EmployeeAddress;
            table.EmployeePhoneNo = employee.EmployeePhoneNo;
            table.EmployeeEmail = employee.EmployeeEmail;
            table.IsActive = employee.IsActive;
            entity.EmployeeTables.Add(table);
            int result = entity.SaveChanges();
            long empId = table.EmployeeId;
            if (result > 0)
            {
                return Ok(empId);

            }
            else
            {

                return BadRequest("Failed to Save");
            }

        }

        [HttpPost]
        [Route("SaveEmployees")]

        public IHttpActionResult SaveEmployees(List<Employee> employee)
        {
            EmpDbEntities entity = new EmpDbEntities();
            employee.ForEach(d =>
            {
                EmployeeTable exist =
                    entity.EmployeeTables.Where(k => k.EmployeeName == d.EmployeeName).FirstOrDefault();
                if (exist != null)
                {
                    throw new Exception("Record is Already exist");
                }
                EmployeeTable table = new EmployeeTable();
                table.EmployeeName = d.EmployeeName;
                table.EmployeeAddress = d.EmployeeAddress;
                table.EmployeeEmail = d.EmployeeEmail;
                table.EmployeePhoneNo = d.EmployeePhoneNo;
                entity.EmployeeTables.Add(table);


            });
            int result = entity.SaveChanges();
            if (result > 0)
            {
                return Ok("Successfully Ssaved");
            }
            else
            {
                return BadRequest("Failed to Save");
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(string employeeName, Employee employee)
        {
            EmpDbEntities entity = new EmpDbEntities();
            EmployeeTable exist =
                entity.EmployeeTables.Where(d => d.EmployeeName == employeeName).FirstOrDefault();
            if (exist != null)
            {
                exist.EmployeeName = employee.EmployeeName;
                exist.EmployeeAddress = employee.EmployeeAddress;
                exist.EmployeeEmail = employee.EmployeeEmail;
                exist.EmployeePhoneNo = employee.EmployeePhoneNo;
                exist.IsActive = employee.IsActive;
                entity.EmployeeTables.Add(exist);
                int result = entity.SaveChanges();
                if (result > 0)
                {
                    return Ok("Successfully updated");
                }
                else
                {
                    return BadRequest("Failed to Update");
                }
            }
            else
            {
                return BadRequest("Failed to Update");
            }



        }

        [HttpDelete]
        [Route("DeleteEmployee")]

        public IHttpActionResult DeleteEmployee(string EmployeeName)
        {
            EmpDbEntities entity = new EmpDbEntities();
            EmployeeTable exist = entity.EmployeeTables.Where(d => d.EmployeeName == EmployeeName).FirstOrDefault();
            if (exist != null)
            {
                entity.EmployeeTables.Remove(exist);
                int res = entity.SaveChanges();
                if (res > 0)
                {
                    return Ok("Successfully Deleted");
                }
                else
                {
                    return BadRequest("Failed to Delete");
                }
            }
            else
            {
                return BadRequest("Failed to Delete");
            }

        }

        [HttpGet]
        [Route("GetEmployee")]
        public IHttpActionResult GetEmployee(string employeeName)
        {
            EmpDbEntities entity = new EmpDbEntities();

            EmployeeTable exist = entity.EmployeeTables.Where(d => d.EmployeeName == employeeName).FirstOrDefault();

            if (exist != null)
            {
                Employee employee = new Employee();
                employee.EmployeeName = exist.EmployeeName;
                employee.EmployeeAddress = exist.EmployeeAddress;
                employee.EmployeeEmail = exist.EmployeeEmail;
                employee.EmployeePhoneNo = exist.EmployeePhoneNo;
                employee.IsActive = exist.IsActive;
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IHttpActionResult GetEmployees()
        {
            EmpDbEntities entity = new EmpDbEntities();
            List<EmployeeTable> employees = entity.EmployeeTables.ToList();
            if (employees.Count > 0)
            {
                List<Employee> result = new List<Employee>();
                employees.ForEach(d =>
                {
                    Employee employee = new Employee();
                    employee.EmployeeName = d.EmployeeName;
                    employee.EmployeeAddress = d.EmployeeAddress;
                    employee.EmployeeEmail = d.EmployeeEmail;
                    employee.EmployeePhoneNo = d.EmployeePhoneNo;
                    result.Add(employee);
                });
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}


