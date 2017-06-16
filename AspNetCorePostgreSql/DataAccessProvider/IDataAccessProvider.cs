using AspNetCorePostgreSql.Model;
using System.Collections.Generic;

namespace AspNetCorePostgreSql.DataAccessProvider
{
    public interface IDataAccessProvider
    {
        void AddBuilding(Building building);
        void UpdateBuilding(long Id, Building building);
        void DeleteBuilding(long Id);
        Building GetBuilding(long Id);
        List<Building> GetBuildings(bool withChildren);
        void AddSuite(Suite suite);
        void UpdateSuite(long Id, Suite suite);
        void DeleteSuite(long Id);
        Suite GetSuite(long Id);
        List<Suite> GetSuites(bool withChildren);
        void AddResident(Resident resident);
        void UpdateResident(long Id, Resident resident);
        void DeleteResident(long Id);
        Resident GetResident(long Id);
        List<Resident> GetResidents();
    }
}
