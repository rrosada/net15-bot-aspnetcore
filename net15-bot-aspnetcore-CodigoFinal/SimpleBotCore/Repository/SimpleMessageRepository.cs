using MongoDB.Driver;
using SimpleBotCore.Logic;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBotCore.Repository
{
    public class SimpleMessageRepository : Interface.ISimpleMessageRepository
    {
        private MongoClient _dbClient = null;        

        public SimpleMessageRepository()
        {
            _dbClient = CreateDbInstance.GetMongoInstance;
        }
        
        //public SimpleMessageRepository(MongoClient dbClient)
        //{
        //    _dbClient = dbClient;
        //}

        public IEnumerable<SimpleMessage> Find(string filter)
        {
            //var _db = _dbClient.GetDatabase("15net");
            //var _collection = _db.GetCollection<SimpleMessage>("col01");

            var _db = _dbClient.GetDatabase(Config.Banco);

            var _collection = _db.GetCollection<SimpleMessage>(Config.Collection);

            var _result = _collection.Find(filter).ToList(); //.FirstOrDefault();

            return _result;
        }

        public void Insert(SimpleMessage message)
        {
            //var _db = _dbClient.GetDatabase("15net");
            //var _collection = _db.GetCollection<SimpleMessage>("col01");

            var _db = _dbClient.GetDatabase(Config.Banco);
                        
            var _collection = _db.GetCollection<SimpleMessage>(Config.Collection);

            _collection.InsertOne(message);
        }
    }
}
