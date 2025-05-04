// File: ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Verto.Models;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }

    // DbSet property for the HomePageContent entity
    public DbSet<HomePageContent> HomePageContents { get; set; }
}