using Microsoft.EntityFrameworkCore;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.Data
{
    public class NTDataHiveContext : DbContext
    {
        public NTDataHiveContext(DbContextOptions<NTDataHiveContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PersonTypes> PersonTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PreEditing> PreEditing { get; set; }
        public DbSet<Revision> Revisions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("DbContext has no connection");
            }
        }
    }
}
