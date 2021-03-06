﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.FoodTruck.DataManagement.Loation.Persistence.DataAccessors
{
    public class LocationDa : IDisposable
    {
        private readonly LocationContext _context;
        public LocationDa()
        {
            _context = new LocationContext();
        }
        public LocationDa(LocationContext context)
        {
            _context = context;
        }
        public void SaveChanges(Location.Entities.Location location)
        {
            try
            {
                _context.Locations.Add(location);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex) 
            {
                //log error here;
                throw;
            }
        }

        public void Dispose()
        {
            _context.Database.CloseConnection();
            _context.Dispose();
        }

        public Location.Entities.Location GetLatestLocation()
        {
            return _context.Locations.OrderByDescending(L=> L.InsertTimeStamp).FirstOrDefault();
        }
    }
}
