﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Equipment>? Equipments { get; set; }
        public DbSet<Payroll>? Payrolls { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<Skill>? Skills { get; set; }
        public DbSet<CompanyCustomer>? CompanyCustomers { get; set; }
        public DbSet<CompanyDepartment>? CompanyDepartments { get; set; }
        public DbSet<CompanyProject>? CompanyProjects { get; set; }
        public DbSet<EmployeeEquipment>? EmployeeEquipments { get; set; }
        public DbSet<EmployeeProject>? EmployeeProjects { get; set; }
        public DbSet<EmployeeSkill>? EmployeeSkills { get; set; }
        public DbSet<ProjectSkill>? ProjectSkills { get; set; }
    }
}
