export enum VacationType{
    VacationLeave = 1,
    SickLeave = 2,
    Holiday = 3
}

export class EmployeeVacation{
    IDEmployeeVacation: Number;
    EmployeeFirstName: String;
    EmployeeLastName: String;
    vacationType : VacationType;
    From: Date;
    To: Date;

    constructor(id: Number, firstName: String, lastName: String, vacationType:VacationType, from: Date, to:Date){
        this.IDEmployeeVacation = id;
        this.EmployeeFirstName = firstName;
        this.EmployeeLastName = lastName;
        this.vacationType = vacationType;
        this.From = from;
        this.To = to;
    }
}