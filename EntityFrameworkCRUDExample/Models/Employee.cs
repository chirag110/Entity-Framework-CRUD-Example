using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace EntityFrameworkCRUDExample.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
    }
    public class CompanyDbContext: DbContext
 {
 public CompanyDbContext() : base(@"data source=localhost\sqlexpress; integrated security=yes; initial catalog=company")
    {
    }
    public DbSet<Employee> Employees { get; set; }
}
}