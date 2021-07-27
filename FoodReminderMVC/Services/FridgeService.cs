using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodReminderMVC.Models;
using MongoDB.Driver;

namespace FoodReminderMVC.Services
{
    public class FridgeService
    {
        private readonly IMongoCollection<Fridge> _fridges;

        public FridgeService(IFridgeReminderDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _fridges = database.GetCollection<Fridge>(settings.FridgeCollectionName);
        }

        public List<Fridge> Get() =>
            _fridges.Find(fridge => true).ToList();

        public Fridge Get(string id) =>
            _fridges.Find<Fridge>(fridge => fridge.Id == id).FirstOrDefault();

        public Fridge Create(Fridge fridge)
        {
            _fridges.InsertOne(fridge);
            return fridge;
        }

        public void Update(string id, Fridge fridgeIn) =>
            _fridges.ReplaceOne(fridge => fridge.Id == id, fridgeIn);

        public void Remove(Fridge fridgeIn) =>
            _fridges.DeleteOne(fridge => fridge.Id == fridgeIn.Id);

        public void Remove(string id) =>
            _fridges.DeleteOne(fridge => fridge.Id == id);
    }
}
