using System.Data.Entity;

namespace SibersProjectsData.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}