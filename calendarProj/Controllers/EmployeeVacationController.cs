using DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;

namespace calendarProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeVacationController : ControllerBase
    {
        private readonly IEmployeeVacationRepo repo = new SQLiteEmployeeVacationRepo();

        [HttpGet]
        public IActionResult GetEmployeeVacations()
        {
            return Ok(repo.GetEmployeeVacations());
        }

        [HttpPut]
        public IActionResult UpdateEmployeeVacation()
        {
            try
            {
                var employee = ParseRequest<EmployeeVacation>();
                repo.UpdateEmployeeVacation(employee);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult InsertEmployeeVacation()
        {
            try
            {
                var employee = ParseRequest<EmployeeVacation>();
                repo.InsertEmployeeVacation(employee);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeVacation([FromQuery] int id)
        {
            try
            {
                repo.DeleteEmployeeVacation(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Helper method for parsing an object from Request body.
        /// </summary>
        /// <typeparam name="T">Type that can be serialized via JSON.</typeparam>
        /// <returns></returns>
        private T ParseRequest<T>()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                var employee = JsonConvert.DeserializeObject<T>(body);
                return employee;
            }
        }
    }
}