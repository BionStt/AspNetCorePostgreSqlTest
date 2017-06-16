using AspNetCorePostgreSql.DataAccessProvider;
using AspNetCorePostgreSql.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCorePostgreSql.Controllers
{
    [Route("api/[controller]")]
    public class SuiteController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public SuiteController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Suite> Get()
        {
            return _dataAccessProvider.GetSuites(true);
        }


        [HttpGet("{id}")]
        public Suite Get(long id)
        {
            return _dataAccessProvider.GetSuite(id);
        }

        [HttpPost]
        public void Post([FromBody]Suite value)
        {
            _dataAccessProvider.AddSuite(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Suite value)
        {
            _dataAccessProvider.UpdateSuite(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _dataAccessProvider.DeleteSuite(id);
        }
    }
}
