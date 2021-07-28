using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodReminderMVC.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? ProductListId { get; set; }

    }
}
