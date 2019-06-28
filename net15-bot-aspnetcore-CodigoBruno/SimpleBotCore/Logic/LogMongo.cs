using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBotCore.Logic
{
    public class LogMongo
    {
        public static string ConnectionString { get; set; }
        public static string Banco { get; set; }
        public static string Collection { get; set; }
        public static IMongoClient client { get; set; }
        public static IMongoDatabase db { get; set; }
        public static IMongoCollection<BsonDocument> col { get; set; }

        public LogMongo()
        {
            client = new MongoClient(ConnectionString);
            db = client.GetDatabase(Banco);
            col = db.GetCollection<BsonDocument>(Collection);
        }

        /*
        public void Iniciar()
        {
            client = new MongoClient(ConnectionString);
            db = client.GetDatabase(Banco);
            col = db.GetCollection<BsonDocument>(Collection);
        }
        */

        public void AdicionaLog(SimpleMessage message)
        {
            var doc = new BsonDocument() {
                { "Id", message.Id },
                { "Usuario", message.User },
                { "Mensagem", message.Text }
            };

            col.InsertOne(doc);            
        }

        public List<BsonDocument> Find(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Id", id);
            
            return col.Find(filter).ToList();

        }

        //private int countLog(SimpleMessage message)        
        //{            
        //    var _result = this.Find(message.Id);

        //    return _result.Count;
        //}
    }
}

