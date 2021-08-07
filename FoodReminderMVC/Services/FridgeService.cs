using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodReminderMVC.Models;
using MongoDB.Bson;
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
            _fridges.Find<Fridge>(fridge => fridge.Id == (id)).FirstOrDefault();

        public Fridge Create(Fridge fridge)
        {
            _fridges.InsertOne(fridge);
            return fridge;
        }

        
        public void Update(string id, Fridge fridgeIn) =>
            _fridges.ReplaceOne(fridge => fridge.Id == (id), fridgeIn);

        public void Remove(Fridge fridgeIn) =>
            _fridges.DeleteOne(fridge => fridge.Id == fridgeIn.Id);

        public void Remove(string id) =>
            _fridges.DeleteOne(fridge => fridge.Id == (id));

        public void PushToProducts(string idFridge, Product product)
        {
            var filter = Builders<Fridge>.Filter.Where(e => e.Id== (idFridge) );
            var update = Builders<Fridge>.Update.Push(e => e.Products, product);
            _fridges.FindOneAndUpdate(filter, update);
            
        }

        public void UpdateToProducts(string idFridge, string idProduct, Product product)
        {
            var filter = Builders<Fridge>.Filter;
            var filterFridgeProduct = filter.And(filter.Where(e => e.Id == (idFridge)),
                filter.ElemMatch(e =>e.Products,p => p.Id == (idProduct)));

            var update = Builders<Fridge>.Update.Set("Products.$",product);
            _fridges.UpdateOne(filterFridgeProduct, update);

        }

        public void DeleteProduct(string idFridge, string idProduct)
        {
            var filter = Builders<Fridge>.Filter.Where(e => e.Id == (idFridge));

            var update = Builders<Fridge>.Update.PullFilter(fridge =>fridge.Products,Builders<Product>.Filter.Eq(x=>x.Id,idProduct));
            _fridges.UpdateOne(filter, update);

        }

    }
}
