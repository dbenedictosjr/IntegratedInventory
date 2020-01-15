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
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;
        private readonly ICategory3Service _Category3Service;

        public ProductController(IProductService ProductService, ICategory3Service Category3Service)
        {
            this._ProductService = ProductService;
            this._Category3Service = Category3Service;
        }

        // GET: Product
        public async Task<IActionResult> Index() => View(await _ProductService.GetAllAsync());

        // GET: Product/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _ProductService.GetByIDAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Category3"] = new SelectList(await _Category3Service.GetAllAsync(), "ID", "Description");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,ShortDesc,LongDesc,Cat3ID,MinStock,MaxStock,Cost,MarkupAmount,MarkupPercent,Price,Vatable,Barcode,Stock,Active")] ProductModel Product)

        {
            //if (ModelState.IsValid)
            //{
                await _ProductService.CreateAsync(Product);
                return RedirectToAction(nameof(Index));
            //}
            ViewData["Category3"] = new SelectList(await _Category3Service.GetAllAsync(), "ID", "Description");
            return View(Product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _ProductService.GetByIDAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            ViewData["Category3"] = new SelectList(await _Category3Service.GetAllAsync(), "ID", "Description");
            return View(Product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Code,ShortDesc,LongDesc,Cat3ID,MinStock,MaxStock,Cost,MarkupAmount,MarkupPercent,Price,Vatable,Barcode,Stock,Active,RowVersion")] ProductModel Product)
        {
            if (id != Product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ProductService.UpdateAsync(Product);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewBag.Message = "Record has been modified by someone else.";
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category3"] = new SelectList(await _Category3Service.GetAllAsync(), "ID", "Description");
            return View(Product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _ProductService.GetByIDAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Product = await _ProductService.GetByIDAsync(id);
            await _ProductService.DeleteAsync(Product);
            return RedirectToAction(nameof(Index));
        }
    }
}
