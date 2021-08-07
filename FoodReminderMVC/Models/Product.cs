using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodReminderMVC.Models
{
    public class Product
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("AddedDate")]
        public DateTime AddedDate { get; set; }
        [BsonElement("ExpirationDate")]
        public DateTime ExpirationDate { get; set; }
        [BsonElement("ProductListId")]
        public int? ProductListId { get; set; }



        public void AddExpirationDate()
        {
            this.ExpirationDate = this.AddedDate.AddDays(14);
        }
        public void AddExpirationDate(DateTime expirationDateTime)
        {
            this.ExpirationDate = expirationDateTime;
        }
    }
}
