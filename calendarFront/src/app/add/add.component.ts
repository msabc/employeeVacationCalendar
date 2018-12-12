import { Component, OnInit } from '@angular/core';
import { VacationType, EmployeeVacation } from '../entities/employeeVacation';
import { DataService } from '../data.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {

  private employee : EmployeeVacation;

  private empFirstName:string;
  private empLastName:string;
  private empFrom:Date;
  private empTo:Date;
  private empLeaveType : VacationType;

  private leaveTypes: string[];
  
  constructor(private data: DataService, private router: Router) { }

  ngOnInit() {

    this.leaveTypes = new Array<string>();

    Object.values(VacationType).forEach(type => {
      if (isNaN(type)) {
        this.leaveTypes.push(type.toString());
      }
    });
  }

  onSubmit(){
    this.employee = new EmployeeVacation(0,this.empFirstName,this.empLastName,this.empLeaveType,this.empFrom,this.empTo);
    this.data.insertEmployee(this.employee).subscribe(() => {
        this.router.navigateByUrl('');
    });
  }
}
