using Microsoft.EntityFrameworkCore;
using DotnetPersonAPI.Models;


namespace DotnetPersonAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
}