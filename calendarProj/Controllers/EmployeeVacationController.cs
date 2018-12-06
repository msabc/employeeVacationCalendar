using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [HttpGet("{id}")]
        public ActionResult<EmployeeVacation> GetEmployeeVacations(int id)
        {
            return new JsonResult(repo.GetEmployeeVacations().ToList().FirstOrDefault(emp => emp.IDEmployeeVacation == id));
        }

        [HttpPut]
        public HttpResponseMessage UpdateEmployeeVacation()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var body = reader.ReadToEnd();
                    var employee = JsonConvert.DeserializeObject<EmployeeVacation>(body);
                    repo.UpdateEmployeeVacation(employee);
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
            }
            catch (System.Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Continue);
            }
        }

        [HttpPost]
        public ActionResult<int> InsertEmployeeVacation([FromBody] EmployeeVacation employeeVacation)
        {
            return new JsonResult(repo.InsertEmployeeVacation(employeeVacation));
        }

        [HttpDelete]
        public ActionResult<int> DeleteEmployeeVacation(int id)
        {
            return new JsonResult(repo.DeleteEmployeeVacation(id));
        }
    }
}