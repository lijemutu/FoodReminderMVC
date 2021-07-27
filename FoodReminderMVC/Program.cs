using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;



namespace FoodReminderMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost");
            var dbList = dbClient.ListDatabases().ToList();
            var database = dbClient.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");
            var document = new BsonDocument { { "student_id", 10000 }, {
                    "scores",
                    new BsonArray {
                        new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                        new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                        new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                        new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                    }
                }, { "class_id", 480 }
            };
            collection.InsertOne(document);
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
