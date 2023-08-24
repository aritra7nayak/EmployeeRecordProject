using EmployeeRecordProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EmployeeRecordProject.DataConnection
{
    public class EmployeeDBContext: DbContext
    {
        public EmployeeDBContext(): base("EmployeeDBConnection") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
      }

}