import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { DataService } from '../data.service';
import { EmployeeVacation, VacationType } from '../entities/employeeVacation';

@Component({
  selector: 'app-calendar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})

export class CalendarComponent implements OnInit {

  view: string = 'month';

  employees: EmployeeVacation[];

  viewDate: Date = new Date();

  events: CalendarEvent[] = [];

  constructor(private data: DataService) { }

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

    if(this.employees != undefined){
      this.employees.forEach(element => {
        this.events.push({
          title:element.vacationType.toString(),
          start: element.From,
          end:element.To
        })
      });
    }
  }
}
