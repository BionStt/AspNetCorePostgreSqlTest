using AspNetCorePostgreSql.DataAccessProvider;
using AspNetCorePostgreSql.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCorePostgreSql.Controllers
{
    [Route("api/[controller]")]
    public class BuildingController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public BuildingController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Building> Get()
        {
            return _dataAccessProvider.GetBuildings(true);
        }


        [HttpGet("{id}")]
        public Building Get(long id)
        {
            return _dataAccessProvider.GetBuilding(id);
        }

        [HttpPost]
        public void Post([FromBody]Building value)
        {
            _dataAccessProvider.AddBuilding(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Building value)
        {
            _dataAccessProvider.UpdateBuilding(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _dataAccessProvider.DeleteBuilding(id);
        }
    }
}
