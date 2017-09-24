using System;
using System.Linq;
using System.Web.Http;
using EmpRestfulService.Entity;
using EmpRestfulService.Models;

namespace EmpRestfulService.Controllers
{
    [RoutePrefix("Photo")]
    public class PhotoController : ApiController
    {
        [HttpPost]
        [Route("SaveModelPhoto")]
        public IHttpActionResult SaveModelPhoto(ModelPhoto photo)
        {
            EmpDbEntities entity = new EmpDbEntities();
            PhotoTable exist = entity.PhotoTables.Where(d => d.EmployeeId == photo.EmployeeId).FirstOrDefault();
            if (exist != null)
            {
                throw new Exception("Photo already exist");
            }

            PhotoTable newData = new PhotoTable();
            newData.Photo = photo.Photo;
            newData.EmployeeId = photo.EmployeeId;
            entity.PhotoTables.Add(newData);
            bool result = entity.SaveChanges() > 0;
            if (result)
            {
                return Ok("Successfully Saved");
            }
            else
            {
                return BadRequest("Failed to Save");
            }
        }

        [HttpGet]
        [Route("GetModelPhoto")]

        public IHttpActionResult GetPhoto(long employeeId)
        {
            EmpDbEntities entity=new EmpDbEntities();
            PhotoTable exist = entity.PhotoTables.Where(d => d.EmployeeId == employeeId).FirstOrDefault();
            if (exist != null)
            {
                ModelPhoto model=new ModelPhoto();
                model.Photo = exist.Photo;
                model.EmployeeId = employeeId;
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }
    }

}

