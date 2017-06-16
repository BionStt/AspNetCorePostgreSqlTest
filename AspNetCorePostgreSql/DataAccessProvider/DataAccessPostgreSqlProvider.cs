using AspNetCorePostgreSql.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCorePostgreSql.DataAccessProvider
{
    public class DataAccessPostgreSqlProvider : IDataAccessProvider
    {
        private readonly DomainModelPostgreSqlContext _context;
        private readonly ILogger _logger;

        public DataAccessPostgreSqlProvider(DomainModelPostgreSqlContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessPostgreSqlProvider");
        }
        //Building
        public void AddBuilding(Building building)
        {
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }
        public void UpdateBuilding(long Id, Building building)
        {
            var entity = _context.Buildings.First(b => b.Id == Id);
            if (entity != null && building.Id == Id)
            {
                _context.Buildings.Update(building);
                _context.SaveChanges();
            }
        }

        public void DeleteBuilding(long Id)
        {
            var entity = _context.Buildings.First(b => b.Id == Id);
            _context.Buildings.Remove(entity);
            _context.SaveChanges();
        }

        public Building GetBuilding(long Id)
        {
            var entity = _context.Buildings.FirstOrDefault(b => b.Id == Id);
            return entity;
        }

        public List<Building> GetBuildings(bool withChildren)
        {
            if (withChildren)
            {
                return _context.Buildings.Include(b => b.Suites).OrderBy(b => b.Name).ToList();
            }

            return _context.Buildings.OrderBy(b => b.Name).ToList();

        }
        //Suite
        public void AddSuite(Suite suite)
        {
            _context.Suites.Add(suite);
            _context.SaveChanges();
        }

        public void UpdateSuite(long Id, Suite suite)
        {
            var entity = _context.Suites.First(s => s.Id == Id);
            if (entity != null && suite.Id == Id)
            {
                _context.Suites.Update(suite);
                _context.SaveChanges();
            }
        }

        public void DeleteSuite(long Id)
        {
            var entity = _context.Suites.First(s => s.Id == Id);
            _context.Suites.Remove(entity);
            _context.SaveChanges();
        }

        public Suite GetSuite(long Id)
        {
            var entity = _context.Suites.FirstOrDefault(s => s.Id == Id);
            return entity;
        }

        public List<Suite> GetSuites(bool withChildren)
        {
            if (withChildren)
            {
                return _context.Suites.Include(s => s.Residents).OrderBy(s => s.Name).ToList();
            }

            return _context.Suites.OrderBy(s => s.Name).ToList();
        }
        //Resident
        public void AddResident(Resident resident)
        {
            _context.Residents.Add(resident);
            _context.SaveChanges();

        }

        public void UpdateResident(long Id, Resident resident)
        {
            var entity = _context.Residents.First(r => r.Id == Id);
            if (entity != null && resident.Id == Id)
            {
                _context.Residents.Update(resident);
                _context.SaveChanges();
            }
        }

        public void DeleteResident(long Id)
        {
            var entity = _context.Residents.First(r => r.Id == Id);
            _context.Residents.Remove(entity);
            _context.SaveChanges();
        }

        public Resident GetResident(long Id)
        {
            var entity = _context.Residents.FirstOrDefault(r => r.Id == Id);
            return entity;
        }

        public List<Resident> GetResidents()
        {
            return _context.Residents.OrderBy(r => r.LastName).ThenBy(r => r.FirstName).ToList();
        }
    }
}
