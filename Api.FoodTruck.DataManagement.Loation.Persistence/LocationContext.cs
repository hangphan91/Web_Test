using Api.FoodTruck.DataManagement.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.FoodTruck.DataManagement.Loation.Persistence
{
    public class LocationContext : DbContext
    {
        private readonly string TablePrefix = "FoodTruck_";
       // private DbConnection _connection;
        public DbSet<Api.FoodTruck.DataManagement.Location.Entities.Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
           var  connectionString = SqlConnectionUtility.GetSqlConnection();
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(TablePrefix + entity.GetTableName());
            }
        }
    }
}
