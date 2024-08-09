# Trello Clone

## Introduction

This is a project to improve skils with `Blazor` and `ASP.NET Core`.
The UI was made using [Blazorise](https://blazorise.com/).
The main point of the application will be project planning, just like in the original application.

## Dependencies
- [Blazorise](https://blazorise.com/) - [The Community Plan/Non-Business License](https://blazorise.com/files/licences/SLA-2023-07.pdf)
- [Blazor.Notifications](https://github.com/Append-IT/Blazor.Notifications) - MIT
- [ChartJs.Blazor](https://github.com/mariusmuntean/ChartJs.Blazor) - MIT

## TODO List

- [ ] User:
  - [x] Adding if there is none in the application.
  - [ ] Editing
  - [x] The user can decide whether and when to receive notifications.
  - [x] The user decides whether to receive notifications today based on whether they are working on projects today. 
- [x] Project:
  - [x] API:
    - [x] Adding
    - [x] Editing
    - [x] Deleting  
  - [x] Client:
    - [x] Adding
    - [x] Editing
    - [x] Deleting  
- [x] Templates:
  - [x] API:
    - [x] Adding
    - [x] Editing
    - [x] Deleting  
  - [x] Client:
    - [x] Adding
    - [x] Editing
    - [x] Deleting
  - [x] Adding new or changing existed after adding column in project view.  
- [x] Tasks:
  - [x] API:
    - [x] Adding
    - [x] Editing
    - [x] Deleting
    - [x] Changing category
  - [x] Client:
    - [x] Adding
    - [x] Editing
    - [x] Deleting
    - [x] Changing category
  - [x] Tags:
    - [x] API:
      - [x] Adding
      - [x] Editing
      - [x] Deleting
    - [x] Client:
      - [x] Adding
      - [x] Editing 
      - [x] Deleting
- [x] Notifications
  - [x] Example notification
  - [x] Summary notification 
- [x] Summary charts
  - [x] Example Chart
  - [x] Charts

## TODO ? list

- [ ] Docker?
- [ ] Moving to SQLite for better API design portability?
- [ ] PWA?
- [ ] Default project?
  - [ ] Don't show default project in lists?
  - [ ] Prohibit deleting and modifying the default project?
  - [ ] Show the default project only when entering a subpage with the project view directly?
  - [ ] After directly switching to the project view, show the window for adding a new project/after the first change, ask about a new project?

## Requirements for use

In its current state, the application is in development and it is recommended to run it through the IDE.

### Required components

- .NET 8
- In [Visual Studio](https://visualstudio.microsoft.com/pl/): `ASP.NET` and web development, or other IDE with the necessary components.
- SQL Server. For configuration see: [appsettings.json](./Trello.Api/appsettings.json)

### Required operations

- Database Migration via [EntityFramework](https://learn.microsoft.com/en-us/aspnet/entity-framework).
- Run appliaction as `<Multiple Startup Projects>` in Visual Studio or API and Client projects in other IDEs. 
