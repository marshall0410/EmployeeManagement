using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeManagement.Data {
    public class ApplicationDbContext : IdentityDbContext<Employee> {
        public ApplicationDbContext (DbContextOptions options) : base(options) { }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<AbsenceType> AbsenceTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grievance> Grievances { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<Employee> ().ToTable ("Employees");
            modelBuilder.Entity<IdentityRole> ().ToTable ("Roles");
            modelBuilder.Entity<IdentityUserToken<string>> ().ToTable ("UserTokens");
            modelBuilder.Entity<IdentityUserRole<string>> ().ToTable ("UserRoles");
            modelBuilder.Entity<IdentityRoleClaim<string>> ().ToTable ("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<string>> ().ToTable ("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>> ().ToTable ("UserLogins");

            //Seeding Data

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "User", NormalizedName = "USER" },
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });

            modelBuilder.Entity<AbsenceType> ().HasData (
                new AbsenceType { Id = 1, Name = "Called In" },
                new AbsenceType { Id = 2, Name = "Sick" },
                new AbsenceType { Id = 3, Name = "Optional" },
                new AbsenceType { Id = 4, Name = "Vacation" });

            modelBuilder.Entity<Department> ().HasData (
                new Department { Id = 1, Name = "Human Resources" },
                new Department { Id = 2, Name = "Information Technology" },
                new Department { Id = 3, Name = "Accounting" },
                new Department { Id = 4, Name = "Operations" });

            modelBuilder.Entity<Employee> ().HasData (
                new Employee {
                    Id = "1",
                        UserName = "george@gmail.com",
                        Email = "george@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumber = "9149526677",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        DepartmentId = 2
                },
                new Employee {
                    Id = "2",
                        UserName = "smith@gmail.com",
                        Email = "smith@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumber = "9149526588",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        DepartmentId = 2
                });

            modelBuilder.Entity<Absence> ().HasData (
                new Absence {
                    Id = 1,
                        EmployeeId = "1",
                        Date = DateTime.Now.AddDays (-3),
                        AbsenceTypeId = 2
                },
                new Absence {
                    Id = 2,
                        EmployeeId = "2",
                        Date = DateTime.Now,
                        AbsenceTypeId = 4
                });

            modelBuilder.Entity<Grievance> ().HasData (
                new Grievance {
                    Id = 1,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        DateSubmitted = DateTime.Now.AddDays (-7),
                        DateAnswered = DateTime.Now.AddDays (-6),
                        EmployeeId = "2",
                        RespondantId = "1"
                },
                new Grievance {
                    Id = 2,
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        DateSubmitted = DateTime.Now.AddDays (-4),
                        DateAnswered = DateTime.Now.AddDays (-3),
                        EmployeeId = "2",
                        RespondantId = "1"
                });

            modelBuilder.Entity<Payroll> ().HasData (
                new Payroll {
                    Id = 1,
                        Month = 5,
                        Year = 2020,
                        PaidSalary = 2698.08f,
                        EmployeeId = "1"
                },
                new Payroll {
                    Id = 2,
                        Month = 6,
                        PaidSalary = 2698.08f,
                        EmployeeId = "1"
                },
                new Payroll {
                    Id = 3,
                        Month = 6,
                        PaidSalary = 3498.08f,
                        EmployeeId = "2"
                },
                new Payroll {
                    Id = 4,
                        Month = 7,
                        PaidSalary = 3498.08f,
                        EmployeeId = "2"
                });

            modelBuilder.Entity<Salary> ().HasData (
                new Salary {
                    Id = 1,
                        AnnualSalary = 32376.96f,
                        EmployeeId = "1",
                        Allowance = 0,
                        Tax = 5.05f,
                        GrossSalary = 44652.43f,
                        NetSalary = 37376.96f
                }, new Salary {
                    Id = 2,
                        AnnualSalary = 41976.96f,
                        EmployeeId = "1",
                        Allowance = 0,
                        Tax = 5.05f,
                        GrossSalary = 53552.43f,
                        NetSalary = 46576.96f
                });
        }
    }
}