#nullable enable
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodReminderMVC.Models;
using FoodReminderMVC.Services;
using FoodReminderMVC.ViewModels;
using MongoDB.Bson;

namespace FoodReminderMVC.Controllers
{
    public class FridgeController : Controller
    {
        private readonly FridgeService _fridgeService;
        public FridgeController(FridgeService fridgeService)
        {
            _fridgeService = fridgeService;
        }

        // VIEW CONTROLLERS

        // GET: FridgeController
        //public ActionResult<List<Fridge>> Index()
        public IActionResult Index()

        {
            var fridges = _fridgeService.Get();
            var fridgesView = new FridgesViewModel()
            {
                Fridges = fridges
            };

            return View(fridgesView);

        }

        // GET: FridgeController/Edit/id
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var fridge = _fridgeService.Get(id);
            var fridgeView = new FridgeViewModel()
            {
                capacity = fridge.Capacity,
                id = fridge.Id,
                name = fridge.Name,
                Products = fridge.Products

            };
            return View(fridgeView);
        }



        // NON VIEW CONTROLLERS

        // GET: FridgeController/id
        //public ActionResult<Fridge> GetOne(string id)
        //{
        //    return _fridgeService.Get(id);
        //}


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



        //PRODUCT SECTION



        [HttpPut]
        public ActionResult<Fridge> InsertProduct(string id,[FromBody] Product product)

        {
            product.AddedDate = DateTime.Now;
            product.Id = ObjectId.GenerateNewId().ToString();
            product.AddExpirationDate();


            _fridgeService.PushToProducts(id,product);
            return _fridgeService.Get(id);

        }

        [HttpPut]
        public ActionResult<Fridge> UpdateProduct(string idFridge,string idProduct, [FromBody] Product product)

        {
            product.AddedDate = DateTime.Now;
            product.Id = ObjectId.GenerateNewId().ToString();
            product.AddExpirationDate();

            _fridgeService.UpdateToProducts(idFridge,idProduct, product);
            return _fridgeService.Get(idFridge);

        }
        //[HttpGet]
        public ActionResult<Fridge> DeleteProduct(string idFridge, string idProduct)
        {
            _fridgeService.DeleteProduct(idFridge, idProduct);
            return _fridgeService.Get(idFridge);
        }

    }
}
