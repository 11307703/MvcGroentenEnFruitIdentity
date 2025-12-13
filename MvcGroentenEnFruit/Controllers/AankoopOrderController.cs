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
    public class AankoopOrderController : Controller
    {
        private readonly GFDbContext _context;

        public AankoopOrderController(GFDbContext context)
        {
            _context = context;
        }

        // GET: AankoopOrder
        public async Task<IActionResult> Index()
        {
            return View(await _context.AankoopOrders.ToListAsync());
        }

        // GET: AankoopOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders
                .FirstOrDefaultAsync(m => m.AankoopOrderId == id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }

            return View(aankoopOrder);
        }

        // GET: AankoopOrder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AankoopOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AankoopOrderId,ArtikelId,Datum,Hoeveelheid")] AankoopOrder aankoopOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aankoopOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aankoopOrder);
        }

        // GET: AankoopOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders.FindAsync(id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }
            return View(aankoopOrder);
        }

        // POST: AankoopOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AankoopOrderId,ArtikelId,Datum,Hoeveelheid")] AankoopOrder aankoopOrder)
        {
            if (id != aankoopOrder.AankoopOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aankoopOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AankoopOrderExists(aankoopOrder.AankoopOrderId))
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
            return View(aankoopOrder);
        }

        // GET: AankoopOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders
                .FirstOrDefaultAsync(m => m.AankoopOrderId == id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }

            return View(aankoopOrder);
        }

        // POST: AankoopOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aankoopOrder = await _context.AankoopOrders.FindAsync(id);
            if (aankoopOrder != null)
            {
                _context.AankoopOrders.Remove(aankoopOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AankoopOrderExists(int id)
        {
            return _context.AankoopOrders.Any(e => e.AankoopOrderId == id);
        }
    }
}
