using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MauiApp2.Data
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;
        public MongoDbService(MongoDbSettings settings)
        {
            try
            {
                var client = new MongoClient(settings.ConnectionString);
                _database = client.GetDatabase(settings.DatabaseName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            try
            {
                return _database.GetCollection<T>(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            
        }
    }
}
