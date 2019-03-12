# easycom
Architecture and Project sample for EasyCom

![](https://easycomtec.blob.core.windows.net/easycomtec/logo-header.png)

This is a project to showcase how to create a clean architecture using following technologies and concepts:

- .NET Core 2.2 RESTful API
- Entity Framework Core
- Clean Architecture
- Angular 7
- TypeScript
- Dependency Injection
- SOLID

In order to install and use this sample, you need to:

- Install Node.JS (latest version to date)
- Install Angular CLI
- Visual Studio (2017 prefered, can be community edition)
- Visual Studio Code
- TypeScript
- SQL Server 2012+

After installation:

- Run the schema compare file for DB First approach, under "Easycom.Database.SQLServer" project. Create a database first, then only run the schema compare to create the database objets
- Change the connection string on "appsettings.json" file under "Easycom.API" project, and provide your database details
- Go to Angular's root folder and run "npm install" to download node_modules
- Run both API (VS Build and Run) and Angular project (ng serve)

Have fun!

Disclaimer:

Domain-driven design (DDD) is an approach to software development for complex needs by connecting the implementation to an evolving mode. It maybe consist on multiple software implementations, depending on programmers knowledege. This DDD implementation does not intend to be a final solution to all problems, it is a implementation of my own understanding, subjected to improvements.
