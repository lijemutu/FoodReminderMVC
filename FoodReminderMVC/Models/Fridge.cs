﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace FoodReminderMVC.Models
{
    public class Fridge
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Capacity")] 
        public int Capacity { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Products")]
        public List<Product> Products { get; set; } = new List<Product>();

        
    }
}
