using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodReminderMVC.ViewModels
{
    public class ProductViewModel
    {
        
        public string Name { get; set; }
       
       
        public string Id { get; set; }
       
        public string Category { get; set; }
     
        public DateTime AddedDate { get; set; }
       
        public DateTime? ExpirationDate { get; set; }
     
 
    }
}
