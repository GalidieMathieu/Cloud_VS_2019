using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_VS_2019
{
    public class Employee
    {
        [BsonId]
        public int Id { get; set;  }

        [BsonElement("birth_date")]
        public string birth_date { get; set; }

        [BsonElement("first_name")]
        public string first_name { get; set; }

        [BsonElement("last_name")]
        public string last_name { get; set; }

        [BsonElement("gender")]
        public string gender { get; set; }

        [BsonElement("hire_date")]
        public string hire_date { get; set; }

        [BsonElement("salaries")]
        public Salaries[] salaries { get; set; }

        [BsonElement("dept")]
        public Dept[] dept { get; set; }

        [BsonElement("titles")]
        public Titles[] titles { get; set; }

    }

    public class Salaries
    {
        [BsonElement("salary")]
        public int salary { get; set; }

        [BsonElement("from_date")]
        public string from_date { get; set; }

        [BsonElement("to_date")]
        public string to_date { get; set; }
    }

    public class Dept
    {
        [BsonElement("dept_no")]
        public string dept_no { get; set; }

        [BsonElement("from_date")]
        public string from_date { get; set; }

        [BsonElement("to_date")]
        public string to_date { get; set; }
    }

    public class Titles
    {
        [BsonElement("title")]
        public string title { get; set; }

        [BsonElement("from_date")]
        public string from_date { get; set; }

        [BsonElement("to_date")]
        public string to_date { get; set; }
    }

    /// <summary>
    /// serialization de la quetion 1
    /// </summary>
      public class Query1
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("first_name")]
        public string first_name { get; set; }

        [BsonElement("last_name")]
        public string last_name { get; set; }

        [BsonElement("Entre_post")]
        public string Entre_post { get; set; }

        [BsonElement("cvtEntre_post")]
        public int cvtEntre_post { get; set; }

        [BsonElement("Post")]
        public int Post { get; set; }
    }

    /// <summary>
    /// serialization de la requête 4
    /// </summary>
    public class Query4
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("sexe")]
        public string sexe { get; set; }

        [BsonElement("nb_emp")]
        public double nb_emp { get; set; }

        [BsonElement("total_emp")]
        public double total_emp { get; set; }

        [BsonElement("percent")]
        public double percent { get; set; }
    }

    /// <summary>
    /// serialization de la requête 5
    /// </summary>
    public class Query5
    {
        [BsonElement("_id")]
        public string dept { get; set; }

        [BsonElement("sum")]
        public double sum { get; set; }

        [BsonElement("totalAmount")]
        public int totalAmount { get; set; }

        [BsonElement("moyenne_salaire")]
        public double moyenne_salaire { get; set; }
    }

    /// <summary>
    /// Moyenne d’âge d’entrée dans un département par poste.
    /// </summary>
    public class Query7
    {
        [BsonElement("_id")]
        public string id { get; set; }

        [BsonElement("sum")]
        public int sum { get; set; }

        [BsonElement("total_age")]
        public int total_age { get; set; }

        [BsonElement("moy_age")]
        public double moy_age { get; set; }
    }

    public class MapReduce
    {
        [BsonElement("_id")]
        public double id { get; set; }

        [BsonElement("value")]
        public double value { get; set; }
    }
}
