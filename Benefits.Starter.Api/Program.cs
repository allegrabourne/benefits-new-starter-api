using Benefits.Starter.Repository;
using Benefits.Starter.Repository.Data;
using Benefits.Starter.Service.Employees;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Hello World!");

builder.Services.AddDbContext<BenefitsStarterDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();
app.Run();
