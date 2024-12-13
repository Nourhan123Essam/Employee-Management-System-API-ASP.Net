using Employee_Management_Stytem.Models.Entities;
using Employee_System_Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Stytem.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Role Employee one-to-many
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Employees)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            //Designation Employee one-to-many
            modelBuilder.Entity<Designation>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Designation)
                .HasForeignKey(e => e.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            //Leader Project one-to-many
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Leader)
                .WithMany(e => e.ProjectsLed)
                .HasForeignKey(p => p.LeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            //Client Project One-to-Many
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Projects)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            //project Employee many-to-many
            //modelBuilder.Entity<Project>()
            //    .HasMany(p => p.Employees)
            //    .WithMany(e => e.Projects)


        }
    }
}
