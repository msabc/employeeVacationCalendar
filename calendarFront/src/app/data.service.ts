import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { EmployeeVacation, VacationType } from '../app/entities/employeeVacation';
import { throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private readonly employeeUrl: string = "https://localhost:44303/api/employeevacation";

  constructor(private http: HttpClient) { }

  getEmployees() {
    return this.http.get(this.employeeUrl);
  }

  updateEmployee(employeeVacation: EmployeeVacation) {
    return this.http.put<EmployeeVacation>(this.employeeUrl, {
      IDEmployeeVacation: employeeVacation.IDEmployeeVacation,
      EmployeeFirstName: employeeVacation.EmployeeFirstName,
      EmployeeLastName: employeeVacation.EmployeeLastName,
      Leave: employeeVacation.vacationType,
      From: employeeVacation.From,
      To: employeeVacation.To
    }).pipe(catchError(this.handleError));
  }

  insertEmployee(employeeVacation: EmployeeVacation) {
    return this.http.post<EmployeeVacation>(this.employeeUrl, employeeVacation);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }

    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };

  removeEmployee(employeeID: Number){
    const url = `${this.employeeUrl}/?id=${employeeID}`;
    return this.http.delete<Number>(url)
    .pipe(
      catchError(this.handleError)
    );
  }

}
