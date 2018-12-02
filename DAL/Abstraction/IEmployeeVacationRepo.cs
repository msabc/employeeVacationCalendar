using System.Collections.Generic;

namespace DAL
{
    public interface IEmployeeVacationRepo
    {
        ICollection<EmployeeVacation> GetEmployeeVacations();
        int UpdateEmployeeVacation(EmployeeVacation employeeVacation);
        int DeleteEmployeeVacation(int id);
        EmployeeVacation InsertEmployeeVacation(EmployeeVacation employeeVacation);
    }
}
