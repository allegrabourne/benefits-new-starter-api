# Benefits New Starter API


## General Information


A Web API for managing new employee starter details.


This project is structured using traditional architecture with separation of concerns for models, services, APIs, data access and tests utilising:


**C#**

**FastEndpoints** for the HTTP API layer

**Entity Framework Core** (Code-First approach)

**SQL Server (localhost)** as the backend database


---


## Business Context


The Benefits New Starter API supports the onboarding process for a benefits platform used by employers to manage employee reward and benefits packages.


When a new employee joins an organisation, their details must be captured and stored so they can:


- Access the employee benefits platform

- Enrol in benefit schemes (e.g., pension, healthcare, salary sacrifice)

- Be provisioned across downstream systems

- Be included in payroll and eligibility processes


This API is responsible for:


- Capturing core starter details

- Generating a unique employee number

- Persisting the employee record

- Ensuring data integrity (e.g., preventing duplicate email addresses)


The system is designed to be:


- Reliable and consistent — starter records are business-critical

- Extensible: Future integrations (HRIS, payroll, ETL pipelines) can be added

- Maintainable: Clean separation of domain, application, and infrastructure layers


Although this implementation focuses on a single use case (creating a new employee), the architecture supports future expansion such as:


- Updating employee details

- Soft deletion / offboarding

- Validation workflows

- Event publication for downstream systems

## How to run

Prerequisites

.NET SDK 10 (or compatible preview)

SQL Server LocalDB (default Windows install)
or update the connection string to your SQL instance.

Apply Database Migrations

From the solution root:

dotnet ef database update \
--project Benefits.Starter.Repository \
--startup-project Benefits.Starter.Api

Run the API
dotnet run --project Benefits.Starter.Api


## API Endpoints

GET /health
https://localhost:7070/health

Add New Starter
POST /employees
https://localhost:7070/employees

{
  "title": 2,
  "firstName": "Allegra",
  "surname": "Bourne",
  "dateOfBirth": "1984-01-01",
  "gender": 1,
  "email": "allegra@example.com",
  "address": {
    "line1": "1 High Street",
    "line2": null,
    "city": "York",
    "postcode": "YO1 1AA",
    "country": "UK"
  }
}

Retrieve Starter by Employee Number
GET /employees/{employeeNo}
https://localhost:7070/employees/EMP443825


