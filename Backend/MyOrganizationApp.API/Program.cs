using Microsoft.EntityFrameworkCore;
using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Application.DTOs;
using MyOrganizationApp.Application.Services.Implementation;
using MyOrganizationApp.Application.Services.Interface;
using MyOrganizationApp.Infrastructure.Data;
using MyOrganizationApp.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyOrgDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<DepartmentMapper>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
