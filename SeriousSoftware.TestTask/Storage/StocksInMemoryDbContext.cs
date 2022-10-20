using SeriousSoftware.TestTask.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace SeriousSoftware.TestTask.Storage
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
