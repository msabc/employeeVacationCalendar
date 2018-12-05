import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {EmployeeVacation, VacationType} from '../app/entities/employeeVacation';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private readonly employeeUrl : string = "https://localhost:44303/api/employeevacation";

  constructor(private http: HttpClient) { }

  getEmployees() {
    return this.http.get(this.employeeUrl);
  }

  updateEmployee(employeeVacation: EmployeeVacation){
    return this.http.put<EmployeeVacation>(this.employeeUrl, employeeVacation);
  }

  insertEmployee(employeeVacation: EmployeeVacation){
    return this.http.post<EmployeeVacation>(this.employeeUrl, employeeVacation);
  }

  /** 
   * Formats the date passed as a parameter into a YYYY/MM/DD format.
   */
  formatDate(date: Date) : Date{
    let strDate = date.toLocaleDateString();
    // date = new Date("Fri Apr 17 2009");
    // Fri Apr 17 2009 00:00:00 GMT+0200 (Central European Summer Time)
    // date.toLocaleString()
    // "4/17/2009, 12:00:00 AM"

    let arrStrDate = strDate.split(", ");
    let arrStr = arrStrDate[0].split("/");
    return new Date(arrStrDate[2]+"/"+arrStrDate[0]+"/"+arrStrDate[1]);
  }
}
