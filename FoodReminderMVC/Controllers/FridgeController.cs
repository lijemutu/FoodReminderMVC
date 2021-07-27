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
        public List<Fridge> Index()
        {
            var fridgesShow = _fridgeService.Get();
            return fridgesShow;
        }

        // GET: FridgeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FridgeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FridgeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FridgeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FridgeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FridgeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FridgeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
