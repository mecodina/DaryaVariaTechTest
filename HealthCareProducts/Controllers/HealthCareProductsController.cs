using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthCareProducts.Models;

namespace HealthCareProducts.Controllers
{
    public class HealthCareProductsController : Controller
    {
        private readonly DaryaVariaContext _context;

        public HealthCareProductsController(DaryaVariaContext context)
        {
            _context = context;
        }

        // GET: HealthCareProducts
        public async Task<IActionResult> Index()
        {
            return _context.HealthCareProducts != null ?
                        View(await _context.HealthCareProducts.ToListAsync()) :
                        Problem("Entity set 'DaryaVariaContext.HealthCareProducts'  is null.");
        }

        // GET: HealthCareProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthCareProducts == null)
            {
                return NotFound();
            }

            var healthCareProduct = await _context.HealthCareProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCareProduct == null)
            {
                return NotFound();
            }

            return View(healthCareProduct);
        }

        // GET: HealthCareProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthCareProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Description,TrademarkName,Composition,Segment,Indication,Dosage,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] HealthCareProduct healthCareProduct)
        {
            if (ModelState.IsValid)
            {
                healthCareProduct.CreatedDate = DateTime.Now;
                #pragma warning disable CA1416 // Validate platform compatibility
                healthCareProduct.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                #pragma warning restore CA1416 // Validate platform compatibility
                _context.Add(healthCareProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthCareProduct);
        }

        // GET: HealthCareProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthCareProducts == null)
            {
                return NotFound();
            }

            var healthCareProduct = await _context.HealthCareProducts.FindAsync(id);
            if (healthCareProduct == null)
            {
                return NotFound();
            }
            return View(healthCareProduct);
        }

        // POST: HealthCareProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Description,TrademarkName,Composition,Segment,Indication,Dosage,UpdatedDate,UpdatedBy")] HealthCareProduct healthCareProduct)
        {
            if (id != healthCareProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    healthCareProduct.UpdatedDate = DateTime.Now;
                    #pragma warning disable CA1416 // Validate platform compatibility
                    healthCareProduct.UpdatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    #pragma warning restore CA1416 // Validate platform compatibility
                    _context.Update(healthCareProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthCareProductExists(healthCareProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(healthCareProduct);
        }

        // GET: HealthCareProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthCareProducts == null)
            {
                return NotFound();
            }

            var healthCareProduct = await _context.HealthCareProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCareProduct == null)
            {
                return NotFound();
            }

            return View(healthCareProduct);
        }

        // POST: HealthCareProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthCareProducts == null)
            {
                return Problem("Entity set 'DaryaVariaContext.HealthCareProducts'  is null.");
            }
            var healthCareProduct = await _context.HealthCareProducts.FindAsync(id);
            if (healthCareProduct != null)
            {
                _context.HealthCareProducts.Remove(healthCareProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthCareProductExists(int id)
        {
            return (_context.HealthCareProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
