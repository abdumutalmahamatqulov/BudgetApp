# BugalteryAPI

## Overview
BugalteryAPI is a financial management API built with ASP.NET Core 9.0. It provides secure authentication and allows users to manage their budgets and transactions efficiently. The backend is powered by Entity Framework Core with PostgreSQL as the database.

## Technologies Used
### Backend:
- **ASP.NET Core 9.0** – Web API framework
- **Entity Framework Core 9.0** – ORM for database interactions
- **PostgreSQL** – Relational database
- **JWT Authentication** – Secure user authentication
- **Middleware** – Custom request processing
- **Swagger (Swashbuckle)** – API documentation

### Frontend:
- **React (JSX)** – Frontend library for UI
- **Ant Design** – UI framework for styled components

## API Base URL
- **Localhost:**
  - `https://localhost:7161`
  - `http://localhost:5090`

## Installation
### Backend Setup
1. Clone the repository:
   ```sh
   git clone https://github.com/abdumutalmahamatqulov/BudgetApp
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Apply database migrations:
   ```sh
   dotnet ef database update
   ```
4. Run the API:
   ```sh
   dotnet run
   ```

### Required .NET Packages
To ensure the backend functions properly, install the following NuGet packages:
```sh
# Authentication & Identity
 dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 9.0.2
 dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 9.0.2
 dotnet add package Microsoft.IdentityModel.Tokens --version 8.6.0
 dotnet add package System.IdentityModel.Tokens.Jwt --version 8.6.0

# Entity Framework Core & PostgreSQL
 dotnet add package Microsoft.EntityFrameworkCore --version 9.0.2
 dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.2
 dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.2
 dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.4

# API Documentation
 dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.2
 dotnet add package Swashbuckle.AspNetCore --version 7.3.1
```

### Frontend Setup
1. Navigate to the frontend folder:
   ```sh
   cd frontend
   ```
2. Install dependencies:
   ```sh
   yarn install
   ```
3. Start the React development server:
   ```sh
   yarn start
   ```

## Features
- User authentication with JWT
- Budget and transaction management
- Secure API endpoints
- Interactive API documentation with Swagger

## Contact
For inquiries or support, contact: **abdumutalmahamatqulov6@gmail.com**

