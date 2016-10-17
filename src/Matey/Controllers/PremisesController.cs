using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matey.Domain.Models.Premises;
using Matey.Service.Premises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Matey.Controllers
{
    public class PremisesController : Controller
    {
        private readonly IPremisesService _premisesService;

        public PremisesController(IPremisesService premisesService)
        {
            _premisesService = premisesService;
        }

        // GET: Premises
        public ActionResult Index()
        {
            return View(_premisesService.GetAll());
        }

        // GET: Premises/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Premises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Premises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Address,Name")] Premises premises)
        {
            if (ModelState.IsValid)
            {
                _premisesService.Create(premises);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Premises/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Premises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Premises/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Premises/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}