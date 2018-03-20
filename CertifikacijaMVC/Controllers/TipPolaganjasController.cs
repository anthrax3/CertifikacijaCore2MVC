using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CertifikacijaMVC.Data;
using CertifikacijaMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CertifikacijaMVC.Controllers
{
    [Authorize]
    public class TipPolaganjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipPolaganjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipPolaganjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipPolaganja.ToListAsync());
        }

        // GET: TipPolaganjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipPolaganja = await _context.TipPolaganja
                .SingleOrDefaultAsync(m => m.TipPolaganjaId == id);
            if (tipPolaganja == null)
            {
                return NotFound();
            }

            return View(tipPolaganja);
        }

        // GET: TipPolaganjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipPolaganjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipPolaganjaId,Tip,TipEng")] TipPolaganja tipPolaganja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipPolaganja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipPolaganja);
        }

        // GET: TipPolaganjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipPolaganja = await _context.TipPolaganja.SingleOrDefaultAsync(m => m.TipPolaganjaId == id);
            if (tipPolaganja == null)
            {
                return NotFound();
            }
            return View(tipPolaganja);
        }

        // POST: TipPolaganjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipPolaganjaId,Tip,TipEng")] TipPolaganja tipPolaganja)
        {
            if (id != tipPolaganja.TipPolaganjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipPolaganja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipPolaganjaExists(tipPolaganja.TipPolaganjaId))
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
            return View(tipPolaganja);
        }

        // GET: TipPolaganjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipPolaganja = await _context.TipPolaganja
                .SingleOrDefaultAsync(m => m.TipPolaganjaId == id);
            if (tipPolaganja == null)
            {
                return NotFound();
            }

            return View(tipPolaganja);
        }

        // POST: TipPolaganjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipPolaganja = await _context.TipPolaganja.SingleOrDefaultAsync(m => m.TipPolaganjaId == id);
            _context.TipPolaganja.Remove(tipPolaganja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipPolaganjaExists(int id)
        {
            return _context.TipPolaganja.Any(e => e.TipPolaganjaId == id);
        }
    }
}
