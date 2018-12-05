using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<int> UpdateEmployeeVacation([FromBody] EmployeeVacation employeeVacation)
        {
            return new JsonResult(repo.UpdateEmployeeVacation(employeeVacation));
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