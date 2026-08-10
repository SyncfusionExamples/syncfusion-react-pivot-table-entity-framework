using Microsoft.EntityFrameworkCore;

namespace PivotTable_EFCore.Server.Data
{
    /// <summary>
    /// DbContext for SalesData entity.
    /// Manages database connections and entity configurations for SQL Server.
    /// </summary>
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

        /// <summary>
        /// DbSet for SalesData entities, representing the 'salesdata' table.
        /// </summary>
        public DbSet<SalesData> SalesData => Set<SalesData>();
    }
}
