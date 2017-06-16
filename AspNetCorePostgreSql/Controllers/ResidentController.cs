using AspNetCorePostgreSql.DataAccessProvider;
using AspNetCorePostgreSql.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCorePostgreSql.Controllers
{
    [Route("api/[controller]")]
    public class ResidentController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public ResidentController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Resident> Get()
        {
            return _dataAccessProvider.GetResidents();
        }


        [HttpGet("{id}")]
        public Resident Get(long id)
        {
            return _dataAccessProvider.GetResident(id);
        }

        [HttpPost]
        public void Post([FromBody]Resident value)
        {
            _dataAccessProvider.AddResident(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Resident value)
        {
            _dataAccessProvider.UpdateResident(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _dataAccessProvider.DeleteResident(id);
        }
    }
}
