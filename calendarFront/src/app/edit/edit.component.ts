import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../data.service';
import { EmployeeVacation } from '../entities/employeeVacation';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  private employee : EmployeeVacation;

  constructor(private route: ActivatedRoute, private data: DataService) { }

  ngOnInit() {
    const employeeID: String = this.route.snapshot.queryParamMap.get('id');

    this.data.getEmployees().subscribe(dat => {
        if(dat instanceof Array){
          let employees = dat as Array<EmployeeVacation>;
          
        }
    });
  }

}
