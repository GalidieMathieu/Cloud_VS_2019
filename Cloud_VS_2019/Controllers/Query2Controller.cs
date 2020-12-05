using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_VS_2019.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Query2Controller : ControllerBase
    {
        private readonly ILogger<Query2Controller> _logger;

        public Query2Controller(ILogger<Query2Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //Initialisation de la collection
            var collection = MongoDBInstance.GetMongoDatabase;


            //R2 
            var filterFindR2 = "{'dept.dept_no' : 'd005'}";
            var resultQuery2 = collection.Find(filterFindR2).ToList();

            return resultQuery2;
            
        }
    }
}
