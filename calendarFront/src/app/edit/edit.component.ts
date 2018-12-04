import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../data.service';
import { EmployeeVacation, VacationType } from '../entities/employeeVacation';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  private leaveTypes: string[];
  private employee: EmployeeVacation;

  constructor(private router: Router, private route: ActivatedRoute, private data: DataService) { }

  ngOnInit() {

    // creating an empty instance to avoid the 'Cannot read property of..' error while still displaying data
    // avoiding the usage of ngIf* which destroys the component if string length is 0
    this.employee = new EmployeeVacation(null,"","",null,null,null);

    this.leaveTypes = new Array<string>();

    Object.values(VacationType).forEach(type => {
      if (isNaN(type)) {
        this.leaveTypes.push(type.toString());
      }
    });

    const employeeID: String = this.route.snapshot.queryParamMap.get('id');


    this.data.getEmployees().subscribe(dat => {

      if (dat instanceof Array) {
        let employeeArray = dat as Array<EmployeeVacation>;
        employeeArray.forEach(emp => {
          let values = Object.entries(emp);

          let id = values[0][1] as string;

          if (id == employeeID) {
            let employeeFirstName = values[1][1] as String;
            let employeeLastName = values[2][1] as String;
            let vacationType = values[3][1] as VacationType;
            let from = values[4][1] as Date;
            let to = values[5][1] as Date;

            this.employee = new EmployeeVacation(parseInt(id), employeeFirstName, employeeLastName, vacationType, from, to);
          }
        });
      }
    });
  }

  onSubmit() {
    this.data.updateEmployee(this.employee).subscribe(dat => {
      this.router.navigateByUrl('');
    });
  }

}
