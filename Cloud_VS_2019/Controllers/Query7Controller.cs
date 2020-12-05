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
    public class Query7Controller : ControllerBase
    {
        private readonly ILogger<Query7Controller> _logger;

        public Query7Controller(ILogger<Query7Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Query7> Get()
        {
            //changement par rapport au début
            //Initialisation de la collection
            var collection = MongoDBInstance.GetMongoDatabase;

            //Q7
            var pipelineQ7 = new BsonDocument[]
            {
                new BsonDocument("$project", new BsonDocument()
                        .Add("birth_date", 1.0)
                        .Add("myField", new BsonDocument()
                                .Add("$slice", new BsonArray()
                                        .Add("$dept.dept_no")
                                        .Add(-1.0)
                                )
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("dept", new BsonDocument()
                                .Add("$arrayElemAt", new BsonArray()
                                        .Add("$myField")
                                        .Add(0.0)
                                )
                        )
                        .Add("birth_date", 1.0)),
                new BsonDocument("$project", new BsonDocument()
                        .Add("dept", 1.0)
                        .Add("BirthYear", new BsonDocument()
                                .Add("$substr", new BsonArray()
                                        .Add("$birth_date")
                                        .Add(0.0)
                                        .Add(4.0)
                                )
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("dept", 1.0)
                        .Add("cvtBirthDate", new BsonDocument()
                                .Add("$toInt", "$BirthYear")
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("dept", 1.0)
                        .Add("cvtBirthDate", 1.0)
                        .Add("Age", new BsonDocument()
                                .Add("$subtract", new BsonArray()
                                        .Add(2000.0)
                                        .Add("$cvtBirthDate")
                                )
                        )),
                new BsonDocument("$group", new BsonDocument()
                        .Add("_id", "$dept")
                        .Add("sum", new BsonDocument()
                                .Add("$sum", 1.0)
                        )
                        .Add("total_age", new BsonDocument()
                                .Add("$sum", "$Age")
                        )
                        .Add("moy_age", new BsonDocument()
                                .Add("$avg", "$Age")
                        ))
            };
            var resultBsonDocumentQ7 = collection.Aggregate<BsonDocument>(pipelineQ7).ToList();
            Query7[] resultQuery7 = new Query7[resultBsonDocumentQ7.Count];
            for (int i = 0; i < resultBsonDocumentQ7.Count; ++i)
            {
                resultQuery7[i] = BsonSerializer.Deserialize<Query7>(resultBsonDocumentQ7[i]);
            }

            return resultQuery7;

        }
    }
}
