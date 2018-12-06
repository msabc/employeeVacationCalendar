# employeeVacationCalendar

An app for a job application.

The application is divided into **3 parts**: 

| Folder        | Purpose  | Technology        |
|---------------|----------|-------------------|
| calendarFront | frontend | Angular 7         |
| calendarProj  | backend  | .NET Core WebAPI  |
| DAL           | data     | .NET Core library |

Backend (server-side) is served on **https://localhost:44303/api/employeevacation**
Frontend (client-side) is served on **https://localhost:4200** (default Angular port)

To run the application, clone the project and open the **calendarProj.sln** (Visual Studio solution) file.
Make sure that the **calendarProj** is set as the _StartupProject_.

After that check if you have Angular installed on your pc:
1) Open command prompt
2) Run **ng --version**

Check the version under _Angular CLI_. This was developed with Angular CLI: 7.0.6.

If you don't have Angular, you won't be able to run the next command in order to serve the client.

Go to the **calendarFront** folder and run the next command: **ng serve**.
