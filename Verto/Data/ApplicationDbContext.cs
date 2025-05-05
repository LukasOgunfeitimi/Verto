// File: ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Verto.Models;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }

    public DbSet<HomePageContent> HomePageContents { get; set; }
}