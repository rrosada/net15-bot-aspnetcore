using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {            
            var mongoClient = new MongoClient();

            var db = mongoClient.GetDatabase("15net");
            //var collection = db.GetCollection<BsonDocument>("col01");

            //var doc = new BsonDocument();
            
            var doc = new BsonDocument()
            {
                { "campo1", 1 },
                { "campo2", 2 },
                { "campo3", new BsonDocument
                            {
                                { "A", 1 }
                            }
                }
            };
            

            //collection.InsertOne(doc);
            
            //var collection = db.GetCollection<BsonDocument>("col01");
            //var doc = new BsonDocument();

            //r_q4b3swn2j8
            //var filter = new SimpleMessage("r_q4b3swn2j8", "", "");
            //var result = collection.Find(filter.Id);

            var collection = db.GetCollection<SimpleMessage>("col01");
            
            
            //collection.InsertOne(message);

            //var result = collection.Find("{Id:r_q4b3swn2j8}");
            //var filter = Builders<SimpleMessage>.Filter.Eq(x => x.Id, "r_q4b3swn2j8");
            
            var filter = new BsonDocument() {
                { "campo1", 1 }
            };
            
            //var result = collection.Find(filter).FirstOrDefault();

            //if(result.Quant <= 0)
                //message.Quant += 1;

            collection.InsertOne(message);
            
            return $"{message.User} disse '{message.Text} quant:' {message.Quant} ";
        }

    }
}