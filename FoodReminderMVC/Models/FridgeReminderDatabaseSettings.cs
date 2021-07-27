using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodReminderMVC.Models
{
    public class FridgeReminderDatabaseSettings : IFridgeReminderDatabaseSettings
    {
        public string FridgeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFridgeReminderDatabaseSettings
    {
        string FridgeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }


    }
}
