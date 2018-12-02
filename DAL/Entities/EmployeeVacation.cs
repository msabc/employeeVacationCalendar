using System;

namespace DAL
{
    public enum VacationType
    {
        VacationLeave = 1,
        SickLeave = 2,
        Holiday = 3
    }

    public class EmployeeVacation
    {
        public int IDEmployeeVacation { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public VacationType Leave { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public EmployeeVacation(string employeeFirstName, string employeeLastName, VacationType leave, DateTime from, DateTime to)
        {
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            Leave = leave;
            From = from;
            To = to;
        }

        public EmployeeVacation(int id, string employeeFirstName, string employeeLastName, VacationType leave, DateTime from, DateTime to)
        {
            IDEmployeeVacation = id;
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            Leave = leave;
            From = from;
            To = to;
        }
    }
}
