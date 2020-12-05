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
    public class Query3Controller : ControllerBase
    {
        private readonly ILogger<Query3Controller> _logger;

        public Query3Controller(ILogger<Query3Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //Initialisation de la collection
            var collection = MongoDBInstance.GetMongoDatabase;

            //R3
            var filterFindR3 = "{'_id' : 10001 }";
            var resultQuery3 = collection.Find(filterFindR3).ToList();

            return resultQuery3;
            
        }
    }
}
