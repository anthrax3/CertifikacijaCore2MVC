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
    public class OdabirTipasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdabirTipasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OdabirTipas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OdabirTipa.Include(o => o.Pitanje).Include(o => o.TipPolaganja);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OdabirTipas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odabirTipa = await _context.OdabirTipa
                .Include(o => o.Pitanje)
                .Include(o => o.TipPolaganja)
                .SingleOrDefaultAsync(m => m.OdabirTipaId == id);
            if (odabirTipa == null)
            {
                return NotFound();
            }

            return View(odabirTipa);
        }

        // GET: OdabirTipas/Create
        public IActionResult Create()
        {
            ViewData["PitanjeId"] = new SelectList(_context.Pitanja, "PitanjeId", "TekstPitanja");
            ViewData["TipPolaganjaId"] = new SelectList(_context.TipPolaganja, "TipPolaganjaId", "Tip");
            return View();
        }

        // POST: OdabirTipas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdabirTipaId,TipPolaganjaId,PitanjeId")] OdabirTipa odabirTipa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odabirTipa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PitanjeId"] = new SelectList(_context.Pitanja, "PitanjeId", "PitanjeId", odabirTipa.PitanjeId);
            ViewData["TipPolaganjaId"] = new SelectList(_context.TipPolaganja, "TipPolaganjaId", "Tip", odabirTipa.TipPolaganjaId);
            return View(odabirTipa);
        }

        // GET: OdabirTipas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odabirTipa = await _context.OdabirTipa.SingleOrDefaultAsync(m => m.OdabirTipaId == id);
            if (odabirTipa == null)
            {
                return NotFound();
            }
            ViewData["PitanjeId"] = new SelectList(_context.Pitanja, "PitanjeId", "PitanjeId", odabirTipa.PitanjeId);
            ViewData["TipPolaganjaId"] = new SelectList(_context.TipPolaganja, "TipPolaganjaId", "Tip", odabirTipa.TipPolaganjaId);
            return View(odabirTipa);
        }

        // POST: OdabirTipas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdabirTipaId,TipPolaganjaId,PitanjeId")] OdabirTipa odabirTipa)
        {
            if (id != odabirTipa.OdabirTipaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odabirTipa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdabirTipaExists(odabirTipa.OdabirTipaId))
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
            ViewData["PitanjeId"] = new SelectList(_context.Pitanja, "PitanjeId", "PitanjeId", odabirTipa.PitanjeId);
            ViewData["TipPolaganjaId"] = new SelectList(_context.TipPolaganja, "TipPolaganjaId", "Tip", odabirTipa.TipPolaganjaId);
            return View(odabirTipa);
        }

        // GET: OdabirTipas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odabirTipa = await _context.OdabirTipa
                .Include(o => o.Pitanje)
                .Include(o => o.TipPolaganja)
                .SingleOrDefaultAsync(m => m.OdabirTipaId == id);
            if (odabirTipa == null)
            {
                return NotFound();
            }

            return View(odabirTipa);
        }

        // POST: OdabirTipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odabirTipa = await _context.OdabirTipa.SingleOrDefaultAsync(m => m.OdabirTipaId == id);
            _context.OdabirTipa.Remove(odabirTipa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdabirTipaExists(int id)
        {
            return _context.OdabirTipa.Any(e => e.OdabirTipaId == id);
        }
    }
}
