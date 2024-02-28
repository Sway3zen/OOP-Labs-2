using lab2_7.Model;
using Microsoft.EntityFrameworkCore;

namespace lab2_7.Data
{
  public class AppDbContext : DbContext
  {
    /*public ApplicationContext(string ConnectionString) {
      Database.EnsureCreated();
    }*/

    public DbSet<UserVm> Users { get; set; } = null!;
    public DbSet<FlightsVm> Flights { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var connectionString = "server=localhost;user=root;password=swayze;database=golobe;";

      optionsBuilder.UseMySql(connectionString,
        new MySqlServerVersion(new Version(8, 0, 34)));
    }

  }
}
