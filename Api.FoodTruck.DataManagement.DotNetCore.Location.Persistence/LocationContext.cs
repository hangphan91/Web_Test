using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Api.FoodTruck.DataManagement.DotNetCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.FoodTruck.DataManagement.DotNetCore.Location.Persistence
{
    public class LocationContext : DbContext
    {
        private readonly string TablePrefix = "FoodTruck_Prod_";
        // private DbConnection _connection;
        public DbSet<Api.FoodTruck.DataManagement.DotNetCore.Location.Definition.Entities.Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionString = SqlConnectionUtility.SqlConnectionUtility.GetSqlConnection();
            optionsBuilder.UseMySql(connectionString);
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
