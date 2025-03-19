using CafeEmployeeTracker.Infrstructure;
using CafeEmployeeTracker.Application;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using CafeEmployeeTracker.Infrstructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using CafeEmployeeTracker.Domain.Repositories;
using CafeEmployeeTracker.Infrstructure.Repositories; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Register Entity Framework Core with Microsoft SQL Server
builder.Services.AddDbContext<CafeEmployeeTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR for CQRS
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Register Autofac as the IoC container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<CafeRepository>().As<ICafeRepository>(); // Fix the method call and type names
    containerBuilder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();   
    //containerBuilder.RegisterType<CafeRepository>().As<ICafeRepository>().InstancePerLifetimeScope();
    //containerBuilder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
});

// Add Layer Service Dependencies
builder.Services.AddServiceApplication(); // This method should be defined in the CafeEmployeeTracker.Application namespace
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CafesEmployeesApp API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CafesEmployeesApp API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
