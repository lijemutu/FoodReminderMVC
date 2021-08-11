using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodReminderMVC.Models;

namespace FoodReminderMVC.ViewModels
{
    public class FridgeViewModel
    {
        public string id { get; set; }
        public int capacity { get; set; }
        public string name { get; set; }
        public List<Product> Products { get; set; }
    }

    public class FridgesViewModel
    {
        public List<Fridge> Fridges { get; set; }
    }
}
