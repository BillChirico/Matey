using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matey.Domain.Models.Premises;
using Matey.Service.PremisesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matey.Controllers
{
    [Route("[controller]")]
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

        // GET: Premises/5
        [Route("{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premises = _premisesService.GetById((int)id);

            if (premises == null)
            {
                return NotFound();
            }

            return View(premises);
        }

        // GET: Premises/Create
        [Route("[controller]/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Premises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/Create")]
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
        [Route("Edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premises = _premisesService.GetById((int) id);

            if (premises == null)
            {
                return NotFound();
            }

            return View(premises);
        }

        // POST: Premises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public IActionResult Edit(int id, [Bind("Id,Address,Name")] Premises premises)
        {
            if (id != premises.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _premisesService.Update(premises);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (_premisesService.GetById(id) == null)
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction("Index");
            }

            return View(premises);
        }

        // GET: Premises/Delete/5
        [Route("Delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premises = _premisesService.GetById((int)id);

            if (premises == null)
            {
                return NotFound();
            }

            return View(premises);
        }

        // POST: Premises/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id?}")]
        public IActionResult Delete(int id)
        {
            var premises = _premisesService.GetById((int)id);

            if (premises == null)
            {
                return NotFound();
            }

            _premisesService.Delete(premises);

            return RedirectToAction("Index");
        }
    }
}