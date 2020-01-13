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
    public class Category3Controller : Controller
    {
        private readonly ICategory3Service _Category3Service;
        private readonly ICategory2Service _Category2Service;

        public Category3Controller(ICategory3Service Category3Service, ICategory2Service Category2Service)
        {
            this._Category3Service = Category3Service;
            this._Category2Service = Category2Service;
        }

        // GET: Category3
        public async Task<IActionResult> Index() => View(await _Category3Service.GetAllAsync());

        // GET: Category3/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category3 = await _Category3Service.GetByIDAsync(id);
            if (Category3 == null)
            {
                return NotFound();
            }

            return View(Category3);
        }

        // GET: Category3/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Category2"] = new SelectList(await _Category2Service.GetAllAsync(), "ID", "Description");
            return View();
        }

        // POST: Category3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Description,Cat2ID")] Category3Model Category3)
        {
            if (ModelState.IsValid)
            {
                await _Category3Service.CreateAsync(Category3);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category2"] = new SelectList(await _Category2Service.GetAllAsync(), "ID", "Description");
            return View(Category3);
        }

        // GET: Category3/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category3 = await _Category3Service.GetByIDAsync(id);
            if (category3 == null)
            {
                return NotFound();
            }
            ViewData["Category2"] = new SelectList(await _Category2Service.GetAllAsync(), "ID", "Description");
            return View(category3);
        }

        // POST: Category3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Code,Description,Cat2ID,RowVersion")] Category3Model Category3)
        {
            if (id != Category3.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Category3Service.UpdateAsync(Category3);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewBag.Message = "Record has been modified by someone else.";
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category2"] = new SelectList(await _Category2Service.GetAllAsync(), "ID", "Description");
            return View(Category3);
        }

        // GET: Category3/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category3 = await _Category3Service.GetByIDAsync(id);
            if (Category3 == null)
            {
                return NotFound();
            }

            return View(Category3);
        }

        // POST: Category3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Category3 = await _Category3Service.GetByIDAsync(id);
            await _Category3Service.DeleteAsync(Category3);
            return RedirectToAction(nameof(Index));
        }
    }
}
