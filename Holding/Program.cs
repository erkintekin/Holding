using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CurrieTechnologies.Razor.SweetAlert2;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSweetAlert2();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));

builder.Services.AddScoped<ISkillService, SkillManager>();
builder.Services.AddScoped<IRepository<Skill>, GenericRepository<Skill>>();
builder.Services.AddScoped<IEquipmentService, EquipmentManager>();
builder.Services.AddScoped<IRepository<Equipment>, GenericRepository<Equipment>>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IRepository<Project>, GenericRepository<Project>>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IRepository<Employee>, GenericRepository<Employee>>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<IRepository<Department>, GenericRepository<Department>>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<IRepository<Company>, GenericRepository<Company>>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IRepository<Customer>, GenericRepository<Customer>>();
builder.Services.AddScoped<IRepository<CompanyCustomer>, GenericRepository<CompanyCustomer>>();
builder.Services.AddScoped<IRepository<CompanyDepartment>, GenericRepository<CompanyDepartment>>();
builder.Services.AddScoped<IRepository<CompanyProject>, GenericRepository<CompanyProject>>();
builder.Services.AddScoped<IRepository<EmployeeEquipment>, GenericRepository<EmployeeEquipment>>();
builder.Services.AddScoped<IRepository<EmployeeProject>, GenericRepository<EmployeeProject>>();
builder.Services.AddScoped<IRepository<EmployeeSkill>, GenericRepository<EmployeeSkill>>();
builder.Services.AddScoped<IRepository<ProjectSkill>, GenericRepository<ProjectSkill>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
