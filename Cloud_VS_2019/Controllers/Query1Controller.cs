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
    public class Query1Controller : ControllerBase
    {
        private readonly ILogger<Query1Controller> _logger;

        public Query1Controller(ILogger<Query1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Query1> Get()
        {
            //Initialisation de la collection
            var collection = MongoDBInstance.GetMongoDatabase;


            //Query 1
            var pipelineQ1 = new BsonDocument[]
            {
                new BsonDocument("$project", new BsonDocument()
                        .Add("first_name", 1.0)
                        .Add("last_name", 1.0)
                        .Add("myField", new BsonDocument()
                                .Add("$slice", new BsonArray()
                                        .Add("$titles.from_date")
                                        .Add(-1.0)
                                )
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("first_name", 1.0)
                        .Add("last_name", 1.0)
                        .Add("Entre_post", new BsonDocument()
                                .Add("$arrayElemAt", new BsonArray()
                                        .Add("$myField")
                                        .Add(0.0)
                                )
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("first_name", 1.0)
                        .Add("last_name", 1.0)
                        .Add("Entre_post", 1.0)
                        .Add("slice_EP", new BsonDocument()
                                .Add("$substr", new BsonArray()
                                        .Add("$Entre_post")
                                        .Add(0.0)
                                        .Add(4.0)
                                )
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("Entre_post", 1.0)
                        .Add("first_name", 1.0)
                        .Add("last_name", 1.0)
                        .Add("cvtEntre_post", new BsonDocument()
                                .Add("$toInt", "$slice_EP")
                        )),
                new BsonDocument("$project", new BsonDocument()
                        .Add("Entre_post", 1.0)
                        .Add("first_name", 1.0)
                        .Add("last_name", 1.0)
                        .Add("cvtEntre_post", 1.0)
                        .Add("Post", new BsonDocument()
                                .Add("$subtract", new BsonArray()
                                        .Add(2002.0)
                                        .Add("$cvtEntre_post")
                                )
                        ))
            };
            var resultBsonDocumentQ1 = collection.Aggregate<BsonDocument>(pipelineQ1).ToList();
            Query1[] resultQuery1 = new Query1[resultBsonDocumentQ1.Count];
            for (int i = 0; i < resultBsonDocumentQ1.Count; ++i)
            {
                resultQuery1[i] = BsonSerializer.Deserialize<Query1>(resultBsonDocumentQ1[i]);
            }

            return resultQuery1;
            
        }
    }
}
