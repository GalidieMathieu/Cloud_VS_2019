using System;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Cloud_VS_2019
{
    public sealed class MongoDBInstance
    {
        //variables liées au singleton
        private static volatile MongoDBInstance instance;
        private static object syncLock = new Object();

        //variables liées à la data Base
        private static IMongoCollection<Employee> collection = null;
        const string uri = "mongodb://devicimongodb048.westeurope.cloudapp.azure.com:30000/";
        private MongoDBInstance() {
            //connexion à la data base
            var client = new MongoClient(uri);
            var dataBase = client.GetDatabase("employeesDB");
            collection = dataBase.GetCollection<Employee>("mini_employees");
        }

        public static IMongoCollection<Employee> GetMongoDatabase {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new MongoDBInstance();
                    }
                }
                return collection;
            }
        }
    }
}
