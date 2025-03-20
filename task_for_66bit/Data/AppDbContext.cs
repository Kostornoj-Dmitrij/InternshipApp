using Microsoft.EntityFrameworkCore;
using task_for_66bit.Data.Models;

namespace task_for_66bit.Data;

public class AppDbContext : DbContext
{
    public DbSet<Intern> Interns { get; set; }
    public DbSet<Direction> Directions { get; set; }
    public DbSet<Project> Projects { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=app.db")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Intern>()
            .HasOne(i => i.Direction)
            .WithMany(d => d.Interns)
            .HasForeignKey(i => i.DirectionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Intern>()
            .HasOne(i => i.Project)
            .WithMany(p => p.Interns)
            .HasForeignKey(i => i.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Intern>()
            .HasIndex(i => i.Email)
            .IsUnique();

        modelBuilder.Entity<Intern>()
            .HasIndex(i => i.PhoneNumber)
            .IsUnique();
        
        modelBuilder.Entity<Direction>().HasData(
            new Direction { Id = 1, Name = "Backend Development", CreatedAt = new DateTime(2023, 10, 1), UpdatedAt = new DateTime(2023, 10, 1) },
            new Direction { Id = 2, Name = "Frontend Development", CreatedAt = new DateTime(2023, 10, 1), UpdatedAt = new DateTime(2023, 10, 1) }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "Project Alpha", CreatedAt = new DateTime(2023, 10, 1), UpdatedAt = new DateTime(2023, 10, 1) },
            new Project { Id = 2, Name = "Project Beta", CreatedAt = new DateTime(2023, 10, 1), UpdatedAt = new DateTime(2023, 10, 1) }
        );
        
        modelBuilder.Entity<Intern>().HasData(
            new Intern
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                Gender = "Мужской",
                Email = "ivan.ivanov@example.com",
                PhoneNumber = "+799912345672",
                DateOfBirth = new DateTime(1990, 1, 1),
                DirectionId = 1,
                ProjectId = 1,
                CreatedAt = new DateTime(2023, 10, 1),
                UpdatedAt = new DateTime(2023, 10, 1)
            }
        );
        
        base.OnModelCreating(modelBuilder);
    }
}