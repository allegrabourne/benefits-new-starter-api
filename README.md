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

