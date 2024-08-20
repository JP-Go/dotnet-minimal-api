namespace MinimalApi.Infrastructure.Db;

using MinimalApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

public class MySqlDBContext : DbContext
{
    public DbSet<Administrator> Administrators { get; set; } = default!;

    private readonly IConfiguration _configuration;

    public MySqlDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>().HasData(new Administrator
        {
            Id = 1,
            Email = "admin@teste.com",
            Password = "admin",
            Role = "admin"
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {

            var connectionString = _configuration.GetConnectionString("mysql")?.ToString();
            if (connectionString is null || connectionString == "")
            {
                throw new ArgumentNullException("Connection string not found");

            }
            optionsBuilder
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging();
        }
    }
}
