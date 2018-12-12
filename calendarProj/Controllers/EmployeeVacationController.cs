using DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace calendarProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeVacationController : ControllerBase
    {
        private readonly IEmployeeVacationRepo repo = new SQLiteEmployeeVacationRepo();

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeVacation>> GetEmployeeVacations()
        {
            return new JsonResult(repo.GetEmployeeVacations());
        }

        [HttpPut]
        public HttpResponseMessage UpdateEmployeeVacation()
        {
            try
            {
                var employee = ParseRequest<EmployeeVacation>();
                repo.UpdateEmployeeVacation(employee);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Continue);
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertEmployeeVacation()
        {
            try
            {
                var employee = ParseRequest<EmployeeVacation>();
                repo.InsertEmployeeVacation(employee);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Continue);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEmployeeVacation([FromQuery] int id)
        {
            try
            {
                repo.DeleteEmployeeVacation(id);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Continue);
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