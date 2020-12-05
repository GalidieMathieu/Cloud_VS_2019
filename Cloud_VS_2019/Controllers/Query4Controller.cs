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
    public class Query4Controller : ControllerBase
    {
        private readonly ILogger<Query4Controller> _logger;

        public Query4Controller(ILogger<Query4Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Query4> Get()
        {
            //Initialisation de la collection
            var collection = MongoDBInstance.GetMongoDatabase;

            //R4
            var pipelineQ4 = new BsonDocument[]
            {
                new BsonDocument("$group", new BsonDocument()
                        .Add("_id", "$gender")
                        .Add("sum", new BsonDocument()
                                .Add("$sum", 1.0))),
                new BsonDocument("$group", new BsonDocument()
                        .Add("_id", BsonNull.Value)
                        .Add("count", new BsonDocument()
                                .Add("$sum", "$sum"))
                        .Add("sexe", new BsonDocument()
                                .Add("$push", new BsonDocument()
                                        .Add("gender", "$_id")
                                        .Add("nombre", "$sum")))),
                new BsonDocument("$unwind", new BsonDocument()
                        .Add("path", "$sexe")),
                new BsonDocument("$project", new BsonDocument()
                        .Add("sexe", "$sexe.gender")
                        .Add("nb_emp", "$sexe.nombre")
                        .Add("total_emp", "$count")
                        .Add("percent", new BsonDocument()
                                .Add("$multiply", new BsonArray()
                                        .Add(new BsonDocument()
                                                .Add("$divide", new BsonArray()
                                                        .Add("$sexe.nombre")
                                                        .Add("$count")))
                                        .Add(100.0))
                        ))
            };
            var resultBsonDocumentQ4 = collection.Aggregate<BsonDocument>(pipelineQ4).ToList();
            Query4[] resultQuery4 = new Query4[resultBsonDocumentQ4.Count];
            for (int i = 0; i < resultBsonDocumentQ4.Count; ++i)
            {
                resultQuery4[i] = BsonSerializer.Deserialize<Query4>(resultBsonDocumentQ4[i]);
            }
            return resultQuery4;
            
        }
    }
}
