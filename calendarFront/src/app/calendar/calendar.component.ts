import { Component, OnInit, ChangeDetectionStrategy, ViewChild } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { DataService } from '../data.service';
import { EmployeeVacation, VacationType } from '../entities/employeeVacation';
import { startOfDay, endOfDay, subDays, addDays, endOfMonth, addHours, isToday } from 'date-fns';
import { Subject } from 'rxjs';

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3'
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF'
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA'
  }
};

@Component({
  selector: 'app-calendar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})

export class CalendarComponent implements OnInit {

  @ViewChild('calendarHeader') header;

  view: string = 'month';

  employees: EmployeeVacation[];

  viewDate: Date = new Date();

  events: CalendarEvent[] = [];

  refresh: Subject<any> = new Subject();

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

        if (this.employees != undefined) {
          this.employees.forEach(element => {
            var color = null;
            switch (element.IDEmployeeVacation) {
              case 1: // VacationLeave
                color = colors.red;
                break;
              case 2: // SickLeave
                color = colors.blue;
                break;
              case 3: // Holiday
                color = colors.yellow;
                break;
              default:
                color = colors.red;
                break;
            }

            this.events.push({
              title: element.EmployeeFirstName + " " + element.EmployeeLastName,
              start: startOfDay(element.From),
              end: endOfDay(element.To),
              color: color
            });
          });
        }
        
        // console.log(this.events);
        // console.log(this.header.todayBtn);
        this.header.todayBtn.nativeElement.click();
        // this.header.viewChange.subscribe();
      }
    });
  }
}
