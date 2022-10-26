# Jap Task 1

This is my solution to the first JAP task.

## Application's main features:

- User authenication
- Admin can view a list of all available students
- Admin can view a list of all available selections
- Admin can view all available programs
- Admin can view lectures and events
- Admin can view report tab
- Admin can manually order table with lectures and events.
- Admin can add, delete and edit lectures or events.
- Admin can create new student and send them their email and password.
- Upon starting the application, table on that page is supporting:
  - ordering from ascending to descending
  - ordering from descending to ascending
  - filtering
  - pagination (4 users per page)
- Students can login and view their informations
- Students can see lectures and events for their selection
- Students and Admin can logout

## Used Technologies

### Frontend

- ReactJS
- react-router-dom
- @reduxjs/toolkit and react-redux
- axios
- moment
- @mui/icons-material
- @mui/material

### Backend

- .Net 6 Web API
- SQL Server database
- Entity Framework Core

## Running Application

To get a local copy up and running follow these simple steps:

1.  Clone the repository
    `https://github.com/nardabr/jap-task-1.git`

2.  Server

- Go to server folder and open `server.sln`
- You will have to add API key for SendGrid. Go to `appSettings.json` and `appSettingsDevelopment.json`. Under `SendGridEmailSettings` -> `"APIKey": "SEND_GRID_API_KEY"` type your key instead of SEND_GRID_API_KEY.
- After that go to terminal and write `cd Server.Database` run `dotnet ef database update`.
- Now write `cd ..` to go back to server, then `cd Server.Api` and start the app with `dotnet watch run`.
- You can test API on this link: `https://localhost:7067/swagger/index.html`

3.  Client

- Go to client folder and run `npm install`
- After that run `npm start` to start the frontend

## Credentials for seeded admin

- email: `admin@email.com`
- password: `Password123$`
