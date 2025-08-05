# Clean Architecture - .NET Core API with CQRS + React Frontend

This project demonstrates a full-stack application using **.NET 9 Web API** with **Clean Architecture**, **CQRS**, **EF Core**, and a **React** frontend.
It follows best practices including validation, domain events, Swagger documentation, and Docker Compose for containerized setup.

---
## Technologies Used
### 🔧 Backend (.NET)
- ASP.NET Core Web API
- Clean Architecture (Domain, Application, Infrastructure, API)
- Entity Framework Core + Migrations
- MediatR (CQRS pattern)
- FluentValidation
- Domain Events
- Swagger / OpenAPI
- Docker Compose (API + PostgreSQL)
- xUnit (Unit Testing)

### Frontend (React)
- React (with TypeScript)
- TailwindCss 

---


### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js & npm](https://nodejs.org/)
- [Docker](https://www.docker.com/)

---

## Local Setup

### Clone the Repository


git clone [https://github.com/microappstech/MiniTrello_Hahn](https://github.com/microappstech/MiniTrello_Hahn).git
cd MiniTrello_Hahn

# Without docker 
## backend 
 - Navigate to api 
 - Restore nugets packages 
    `dotnet restore `
 - Run project 
    `Dotnet run`


## front end
- Navigate to project
    `cd Client/mini_trello`

- Install dependencies:
    `npm install`

copy url backend into your front end `http://localhost:50001/api` to MiniTrello_Hahn\client\mini_trello\src\services\boardService.ts
API_URL = "http://localhost:50001/api"

npm start
http://localhost:3000


# Running with Docker Compose
To run backend API and database together in Docker containers:

bash
Copy code
docker-compose up --build
To stop the containers:

bash
Copy code
docker-compose down
Environment Variables
Variable	Description	Example
REACT_APP_API_URL	Base URL for the backend API	http://localhost:8080/api
ConnectionStrings__DefaultConnection	Backend SQL Server connection string	Server=sqlserver;Database=MiniTrelloDB;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=true;
