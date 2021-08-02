#nullable enable
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodReminderMVC.Models;
using FoodReminderMVC.Services;

namespace FoodReminderMVC.Controllers
{
    public class FridgeController : Controller
    {
        private readonly FridgeService _fridgeService;
        public FridgeController(FridgeService fridgeService)
        {
            _fridgeService = fridgeService;
        }
        // GET: FridgeController
        public ActionResult<List<Fridge>> Index()
        {
            return _fridgeService.Get();
        }

        // GET: FridgeController/id
        public ActionResult<Fridge> GetOne(string id)
        {
            return _fridgeService.Get(id);
        }


        // POST: FridgeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult<Fridge> Create([FromBody]Fridge fridge)
        {
            Fridge fridgeAdded = _fridgeService.Create(fridge);
            return fridgeAdded;
        }

        // PUT: FridgeController/Update/id                                            
        [HttpPut]
        public ActionResult<Fridge> Update(string id, [FromBody] Fridge fridgeIn)
        {
            _fridgeService.Update(id, fridgeIn);
            return _fridgeService.Get(id);
        }



        // GET: FridgeController/Delete/5
        public ActionResult<string> Delete(string id)
        {
            _fridgeService.Remove(id);
            return $"Id removed: {id}";
        }
        [HttpPut]
        public ActionResult<Fridge> InsertProduct(string id,[FromBody] Product product)

        {
            product.AddedDate = DateTime.Now;
            _fridgeService.PushToProducts(id,product);
            return _fridgeService.Get(id);

        }
    }
}
