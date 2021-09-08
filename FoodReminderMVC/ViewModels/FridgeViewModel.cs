using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodReminderMVC.Models;

namespace FoodReminderMVC.ViewModels
{
    public class FridgeViewModel
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class FridgesViewModel
    {
        public List<Fridge> Fridges { get; set; }
    }
}
