using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit.Data;
using MvcGroentenEnFruit.Models;

namespace MvcGroentenEnFruit.Controllers
{
    public class VerkoopOrderController : Controller
    {
        private readonly GFDbContext _context;

        public VerkoopOrderController(GFDbContext context)
        {
            _context = context;
        }

        // GET: VerkoopOrder
        public async Task<IActionResult> Index()
        {
            return View(await _context.VerkoopOrders.ToListAsync());
        }

        // GET: VerkoopOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verkoopOrder = await _context.VerkoopOrders
                .FirstOrDefaultAsync(m => m.VerkoopOrderId == id);
            if (verkoopOrder == null)
            {
                return NotFound();
            }

            return View(verkoopOrder);
        }

        // GET: VerkoopOrder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VerkoopOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VerkoopOrderId,ArtikelId,Datum,Hoeveelheid")] VerkoopOrder verkoopOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verkoopOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verkoopOrder);
        }

        // GET: VerkoopOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verkoopOrder = await _context.VerkoopOrders.FindAsync(id);
            if (verkoopOrder == null)
            {
                return NotFound();
            }
            return View(verkoopOrder);
        }

        // POST: VerkoopOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VerkoopOrderId,ArtikelId,Datum,Hoeveelheid")] VerkoopOrder verkoopOrder)
        {
            if (id != verkoopOrder.VerkoopOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verkoopOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerkoopOrderExists(verkoopOrder.VerkoopOrderId))
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
            return View(verkoopOrder);
        }

        // GET: VerkoopOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verkoopOrder = await _context.VerkoopOrders
                .FirstOrDefaultAsync(m => m.VerkoopOrderId == id);
            if (verkoopOrder == null)
            {
                return NotFound();
            }

            return View(verkoopOrder);
        }

        // POST: VerkoopOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verkoopOrder = await _context.VerkoopOrders.FindAsync(id);
            if (verkoopOrder != null)
            {
                _context.VerkoopOrders.Remove(verkoopOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerkoopOrderExists(int id)
        {
            return _context.VerkoopOrders.Any(e => e.VerkoopOrderId == id);
        }
    }
}
