# Trello Clone

## Introduction

This is a project to improve skils with `Blazor` and `ASP.NET Core`.
The UI was made using [Blazorise](https://blazorise.com/).
The main point of the application will be project planning, just like in the original application. However, unlike the original, the app is planned for local use.

## TODO List

- User:
  - [x] Adding if there is none in the application.
  - [ ] Editing
- Project:
  - API:
    - [ ] Adding
    - [ ] Editing
    - [ ] Deleting  
  - Client:
    - [ ] Adding
    - [ ] Editing
    - [ ] Deleting  
- Templates:
  - API:
    - [ ] Adding
    - [ ] Editing
    - [ ] Deleting  
  - Client:
    - [ ] Adding
    - [ ] Editing
    - [ ] Deleting  
- Tasks:
  - API:
    - [ ] Adding
    - [x] Editing
    - [ ] Deleting
    - [ ] Changing category
  - Client:
    - [x] Adding
    - [x] Editing
    - [x] Deleting
    - [x] Changing category
  - [ ] Tags
  - [ ] Importance ranking
- [ ] Notifications
- [ ] Summary charts
- [ ] Docker

## Requirements for use

In its current state, the application is in production and it is recommended to run it through the IDE.

### Required components

- .NET 8
- In [Visual Studio](https://visualstudio.microsoft.com/pl/): `ASP.NET` and web development, or other IDE with the necessary components.
- SQL Server. For configuration see: [appsettings.json](./Trello.Api/appsettings.json)

### Required operations

- Profile pictures aren't uploaded so in this state you needs to remove user from database and after application started it should ask for creating new user. Another solution is to manually upload a file with the appropriate name, which is in the database to the Uploads folder in API project.
- Database Migration via [EntityFramework](https://learn.microsoft.com/en-us/aspnet/entity-framework).
- Run appliaction as `<Multiple Startup Projects>` in Visual Studio or API and Client projects in other IDEs. 