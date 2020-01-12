using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Infrastructure.Interfaces;
using System.Infrastructure.Models;

namespace Online_Store.UI.Controllers
{
    public class Category1Controller : Controller
    {
        private readonly ICategory1Service _Category1Service;

        public Category1Controller(ICategory1Service Category1Service) => this._Category1Service = Category1Service;

        // GET: Category1
        public async Task<IActionResult> Index() => View(await _Category1Service.GetAllAsync());

        // GET: Category1s/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category1 = await _Category1Service.GetByIDAsync(id);
            if (Category1 == null)
            {
                return NotFound();
            }

            return View(Category1);
        }

        // GET: Category1/Create
        public IActionResult Create() => View();

        // POST: Category1s/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Description")] Category1Model Category1)
        {
            if (ModelState.IsValid)
            {
                await _Category1Service.CreateAsync(Category1);
                return RedirectToAction(nameof(Index));
            }
            return View(Category1);
        }

        // GET: Category1s/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category1 = await _Category1Service.GetByIDAsync(id);
            if (Category1 == null)
            {
                return NotFound();
            }
            return View(Category1);
        }

        // POST: Category1s/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Code,Description,RowVersion")] Category1Model Category1)
        {
            if (id != Category1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Category1Service.UpdateAsync(Category1);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewBag.Message = "Record has been modified by someone else.";
                }
            }
            return View(Category1);
        }

        // GET: Category1s/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category1 = await _Category1Service.GetByIDAsync(id);
            if (Category1 == null)
            {
                return NotFound();
            }

            return View(Category1);
        }

        // POST: Category1s/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Category1 = await _Category1Service.GetByIDAsync(id);
            await _Category1Service.DeleteAsync(Category1);
            return RedirectToAction(nameof(Index));
        }
    }
}