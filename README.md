# Jap Task 1

This is my solution to the first JAP task.

## Application's main features:

- User authenication
- View a list of all available students
- View a list of all available selections
- View all available programs
- Upon starting the application, table on that page is supporting:
  - ordering from ascending to descending
  - ordering from descending to ascending
  - filtering
  - pagination (4 users per page)

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
- After that from terminal run `dotnet ef database update`
- You can test API on this link: `https://localhost:7067/swagger/index.html`

3.  Client

- Go to client folder and run `npm install`
- After that run `npm start` to start the frontend

## Credentials for seeded admin

- email: `admin@email.com`
- password: `Password123$`
