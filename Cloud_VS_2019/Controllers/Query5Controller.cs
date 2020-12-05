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
    public class Query5Controller : ControllerBase
    {
        private readonly ILogger<Query5Controller> _logger;

        public Query5Controller(ILogger<Query5Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Query5> Get()
        {
            //Initialisation de la collection
            var collection = MongoDBInstance.GetMongoDatabase;

            //R5
            var pipelineQ5 = new BsonDocument[]
                {
                new BsonDocument("$project", new BsonDocument()
                        .Add("myField", new BsonDocument()
                                .Add("$slice", new BsonArray()
                                        .Add("$salaries.salary")
                                        .Add(-1.0)
                                )
                        )
                        .Add("myField2", new BsonDocument()
                                .Add("$slice", new BsonArray()
                                        .Add("$dept.dept_no")
                                        .Add(-1.0)
                                )
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("salaire", new BsonDocument()
                                .Add("$arrayElemAt", new BsonArray()
                                        .Add("$myField")
                                        .Add(0.0)
                                )
                        )
                        .Add("dept", new BsonDocument()
                                .Add("$arrayElemAt", new BsonArray()
                                        .Add("$myField2")
                                        .Add(0.0)
                                )
                        )),
                new BsonDocument("$group", new BsonDocument()
                        .Add("_id", "$dept")
                        .Add("sum", new BsonDocument()
                                .Add("$sum", 1.0)
                        )
                        .Add("totalAmount", new BsonDocument()
                                .Add("$sum", "$salaire")
                        )
                        .Add("moyenne_salaire", new BsonDocument()
                                .Add("$avg", "$salaire")
                        ))
            };
            var resultBsonDocumentQ5 = collection.Aggregate<BsonDocument>(pipelineQ5).ToList();
            Query5[] resultQuery5 = new Query5[resultBsonDocumentQ5.Count];
            for (int i = 0; i < resultBsonDocumentQ5.Count; ++i)
            {
                resultQuery5[i] = BsonSerializer.Deserialize<Query5>(resultBsonDocumentQ5[i]);
            }
            return resultQuery5;

        }
    }
}
