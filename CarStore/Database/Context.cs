using CarStore.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Database;

public class Context : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Image> Images { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }
}
