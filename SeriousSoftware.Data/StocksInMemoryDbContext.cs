using SeriousSoftware.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SeriousSoftware.Data
{
    public class StocksInMemoryDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "StocksDb");
        }
        public DbSet<StockPrice> StockPrices { get; set; }
    }
}
