import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { EmployeeVacation } from '../entities/employeeVacation';
import { VacationType } from '../entities/employeeVacation';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  employees: EmployeeVacation[];

  constructor(private data: DataService, private router: Router) { }

  ngOnInit() {
    this.data.getEmployees().subscribe(dat => {

      if (dat instanceof Array) {
        let employeeArray = dat as Array<EmployeeVacation>;
        this.employees = new Array();
        employeeArray.forEach(emp => {
          let values = Object.entries(emp);

          // since these are key value pairs at this point organized as 
          // idEmployeeVacation, 1 -> we can index them as follows (since we only need the values)

          let employeeID = values[0][1] as Number;
          let employeeFirstName = values[1][1] as String;
          let employeeLastName = values[2][1] as String;
          let vacationType = values[3][1] as VacationType;
          let from = values[4][1] as Date;
          let to = values[5][1] as Date;

          this.employees.push(new EmployeeVacation(employeeID, employeeFirstName, employeeLastName, vacationType, from, to));
        });
      }
    });
  }

  removeEmployee(employee) {
    if (confirm("Are you sure you want to delete the records of this employee?")) {
      this.data.removeEmployee(employee.IDEmployeeVacation).subscribe(dat => {
        this.router.navigateByUrl('');
      });
    }
  }
}
