using Microsoft.EntityFrameworkCore;
using BaseArchitecture.Entities;

namespace BaseArchitecture.DAL.Concrete
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }

}
