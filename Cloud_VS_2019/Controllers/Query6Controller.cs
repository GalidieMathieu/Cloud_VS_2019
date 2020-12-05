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
    public class Query6Controller : ControllerBase
    {
        private readonly ILogger<Query6Controller> _logger;

        public Query6Controller(ILogger<Query6Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //Initialisation de la collection
            var collection = MongoDBInstance.GetMongoDatabase;

            //cette fonction map reduce ne marche pas 


            var map = new BsonJavaScript(@"
                var mapFunction = function () {
                nb=0;
                sub =0;
                //nom = this.first_name; 
                for(var i=0 ; i<this.salaries.length;i++){
                    salaries = this.salaries[i]
                    anneefin = salaries.to_date.substring(0,4);
                    anneedeb = salaries.from_date.substring(0,4);
                    if ( anneefin != '9999'){
                        sub = parseInt(anneefin) - parseInt(anneedeb);
                    }
                    else{anneefin = 2002; sub = anneefin - parseInt(anneedeb);
                }
                    if(sub>nb){nb = sub;}}
                emit(this._id, nb);         
            }; ");

            var reduce = new BsonJavaScript(@"
                var map =function (key, values) {return values;};");

            var options = new MapReduceOptions<Employee, BsonDocument>
            {
                OutputOptions = MapReduceOutputOptions.Inline
            };
            var res = collection.MapReduce(map, reduce, options); ;


            //R2 on met un return requete 2 pour ne pas avoir de problème lors de la navigation
            var filterFindR2 = "{'dept.dept_no' : 'd005'}";
            var resultQuery2 = collection.Find(filterFindR2).ToList();

            return resultQuery2;
            
        }
    }
}
