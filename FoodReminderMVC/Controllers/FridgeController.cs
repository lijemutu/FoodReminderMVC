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
        [HttpGet]
        public IActionResult Index()

        {
            var fridges = _fridgeService.Get();
            var fridgesView = new FridgesViewModel()
            {
                Fridges = fridges
            };

            return View(fridgesView);

        }

        // GET: FridgeController/Edit/{id}
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var fridge = _fridgeService.Get(id);
            var fridgeView = new FridgeViewModel()
            {
                Capacity = fridge.Capacity,
                Id = fridge.Id,
                Name = fridge.Name,
                Products = fridge.Products

            };
            return View(fridgeView);
        }


        // GET: FridgeController/Create/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(string Id)
        {
            var fridge = _fridgeService.Get(Id);
            var fridgeView = new FridgeViewModel()
            {
                Capacity = fridge.Capacity,
                Id = fridge.Id,
                Name = fridge.Name,
                Products = fridge.Products

            };
            return View(fridgeView);
        }

        [HttpGet]
        public IActionResult InsertProduct()

        {
            return View();

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
        public ActionResult<Fridge> Create([FromForm] string fridgeName, [FromForm] int fridgeCapacity)
        {
            var fridge = new Fridge() {Capacity = fridgeCapacity, Name = fridgeName };
            Fridge fridgeAdded = _fridgeService.Create(fridge);
            return RedirectToAction("Index");
        }

        // PUT: FridgeController/Update/id                                            
        [HttpPost]
        public ActionResult<Fridge> Update(string id, [FromForm] string fridgeName,[FromForm] int fridgeCapacity)
        {
            var fridge = _fridgeService.Get(id);
            var fridgeIn = new Fridge()
            {
                Id = id,
                Capacity = fridgeCapacity,
                Name = fridgeName,
                Products = fridge.Products
            };
            _fridgeService.Update(id, fridgeIn);
            return RedirectToAction("Index");
        }



        // GET: FridgeController/Delete/5
        [HttpPost]
        public IActionResult Delete(string id)
        {
            _fridgeService.Remove(id);
            return RedirectToAction("Index");
        }



        //PRODUCT SECTION



        [HttpPost]
        public ActionResult<Fridge> InsertProduct(string id, [FromForm] string productName, [FromForm] DateTime productExpirationDate)

        {
            if(productExpirationDate == DateTime.MinValue)
            {
                productExpirationDate = DateTime.Now.AddDays(14);
            }
            var product = new Product()
            {
                Name = productName,
                AddedDate = DateTime.Now,
                Id = ObjectId.GenerateNewId().ToString(),
                ExpirationDate = productExpirationDate
            };
            
            
            _fridgeService.PushToProducts(id,product);
            return RedirectToAction("Index");

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
        [HttpPost]
        public IActionResult DeleteProduct(string idFridge, string idProduct)
        {
            _fridgeService.DeleteProduct(idFridge, idProduct);
            return RedirectToAction("Index");
        }


    }
}
