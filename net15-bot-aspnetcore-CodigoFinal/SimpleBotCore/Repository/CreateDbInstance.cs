using MongoDB.Driver;

namespace SimpleBotCore.Repository
{
    public class CreateDbInstance
    {
        private static MongoClient _mongoInstance = null;

        public static MongoClient GetMongoInstance
        {
            get
            {
                if (_mongoInstance == null)

                    //_mongoInstance = new MongoClient("mongodb://localhost:27017");
                    _mongoInstance = new MongoClient(Logic.Config.ConnectionString);
                return _mongoInstance;
            }
        }
    }
}
