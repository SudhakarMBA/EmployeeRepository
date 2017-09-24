using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EmpRestfulService.Entity;
using EmpRestfulService.Models;

namespace EmpRestfulService.Controllers
{
    [RoutePrefix("Salary")]
    public class SalaryController : ApiController
    {

        [HttpPost]
        [Route("SaveModelSalary")]
        public IHttpActionResult SaveModelSalary(ModelSalary salary)
        {
            EmpDbEntities entity = new EmpDbEntities();
            SalaryTable exist = entity.SalaryTables.Where(d => d.EmployeeId == salary.EmployeeId).FirstOrDefault();
            if (exist != null)
            {
                throw new Exception("The salary already added for this employee.");
            }
            SalaryTable table = new SalaryTable();
            table.Salary = salary.Salary;
            table.EmployeeId = salary.EmployeeId;
            entity.SalaryTables.Add(table);
           int result = entity.SaveChanges();
            if (result > 0)
            {
                return Ok("Successfully save");
            }
            else
            {
                return BadRequest("Failed to Save");
            }
        }

        [HttpPost]
        [Route("SaveModelSalarys")]
        public IHttpActionResult SaveModelSalarys(List<ModelSalary> salary)
        {
            EmpDbEntities entity = new EmpDbEntities();
            salary.ForEach(d =>
            {
                SalaryTable exist = entity.SalaryTables.Where(k => k.EmployeeId == d.EmployeeId).FirstOrDefault();
                if (exist != null)
                {
                    throw new Exception("Record is Already exist");
                }
                SalaryTable table = new SalaryTable();
                table.Salary = d.Salary;
                table.EmployeeId = d.EmployeeId;
                entity.SalaryTables.Add(table);

            });
            int result = entity.SaveChanges();
            if (result > 0)
            {
                return Ok("Successfully Saved");
            }
            else
            {
                return BadRequest("Failed to Save");
            }
        }

        [HttpGet]
        [Route("GetModelSalary")]
        public IHttpActionResult GetModelSalary(long employeeId)
        {
            EmpDbEntities entity = new EmpDbEntities();
            SalaryTable exist = entity.SalaryTables.Where(d => d.EmployeeId == employeeId).FirstOrDefault();
            if (exist != null)
            {
                ModelSalary model = new ModelSalary();
                model.Salary = Convert.ToSingle(exist.Salary);
                model.EmployeeId = employeeId;
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetModelSalarys")]
        public IHttpActionResult GetmodelSalarys()
        {
            EmpDbEntities entity = new EmpDbEntities();
            List<SalaryTable> salarys = entity.SalaryTables.ToList();
            if (salarys.Count > 0)
            {
                List<SalaryTable> result = new List<SalaryTable>();
                salarys.ForEach(d =>
                {
                    SalaryTable table = new SalaryTable();
                    table.Salary = d.Salary;
                    table.EmployeeId = d.EmployeeId;
                    result.Add(table);
                });
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("UpdateModelSalary")]
        public IHttpActionResult UpdateModelSalary(long employeeId, ModelSalary salary)
        {
            EmpDbEntities entity = new EmpDbEntities();
            SalaryTable exist = entity.SalaryTables.Where(d => d.EmployeeId == employeeId).FirstOrDefault();
            if (exist != null)
            {
                SalaryTable table = new SalaryTable();
                table.Salary = salary.Salary;
                table.EmployeeId = employeeId;
                entity.SalaryTables.AddOrUpdate(table);
                int result = entity.SaveChanges();
                if (result > 0)
                {
                    return Ok("Successfully Updated");
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
        [Route("DeleteModelSalary")]

        public IHttpActionResult DeleteModelSalary(long employeeId)
        {
            EmpDbEntities entity = new EmpDbEntities();
            SalaryTable exist = entity.SalaryTables.Where(k => k.EmployeeId == employeeId).FirstOrDefault();
            if (exist != null)
            {
                entity.SalaryTables.Remove(exist);
                int result = entity.SaveChanges();
                if (result > 0)
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
    }
}
