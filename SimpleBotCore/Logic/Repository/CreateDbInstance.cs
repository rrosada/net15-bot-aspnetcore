using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Logic.Repository
{
    public class CreateDbInstance
    {
        private static MongoClient _mongoInstance = null;

        public static MongoClient GetMongoInstance
        {
            get
            {
                if (_mongoInstance == null)

                    _mongoInstance = new MongoClient("mongodb://localhost:27017");

                return _mongoInstance;
            }
        }
    }
}
