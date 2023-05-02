using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace EfcDataAccess;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source = ../EfcDataAccess/FakeReddit.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<Post>().HasKey(post => post.postId);
        modelBuilder.Entity<User>().Property(e => e.Email).HasMaxLength(100).IsRequired()
            .HasAnnotation("DataType", "EmailAddress");
    }
    
    
}