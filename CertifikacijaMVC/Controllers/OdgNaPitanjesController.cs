using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CertifikacijaMVC.Data;
using CertifikacijaMVC.Models;

namespace CertifikacijaMVC.Controllers
{
    public class OdgNaPitanjesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdgNaPitanjesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OdgNaPitanjes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OdgNaPitanjes.Include(o => o.OdabirTipa).Include(o => o.Odgovor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OdgNaPitanjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgNaPitanje = await _context.OdgNaPitanjes
                .Include(o => o.OdabirTipa)
                .Include(o => o.Odgovor)
                .SingleOrDefaultAsync(m => m.OdgNaPitanjeId == id);
            if (odgNaPitanje == null)
            {
                return NotFound();
            }

            return View(odgNaPitanje);
        }

        // GET: OdgNaPitanjes/Create
        public IActionResult Create()
        {
            ViewData["OdabirTipaId"] = new SelectList(_context.OdabirTipas, "OdabirTipaId", "OdabirTipaId");
            ViewData["OdgovorId"] = new SelectList(_context.Odgovori, "OdgovorId", "TekstOdgovora");
            return View();
        }

        // POST: OdgNaPitanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdgNaPitanjeId,OdabirTipaId,OdgovorId,Tačno,TipOdgovora")] OdgNaPitanje odgNaPitanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odgNaPitanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OdabirTipaId"] = new SelectList(_context.OdabirTipas, "OdabirTipaId", "OdabirTipaId", odgNaPitanje.OdabirTipaId);
            ViewData["OdgovorId"] = new SelectList(_context.Odgovori, "OdgovorId", "TekstOdgovora", odgNaPitanje.OdgovorId);
            return View(odgNaPitanje);
        }

        // GET: OdgNaPitanjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgNaPitanje = await _context.OdgNaPitanjes.SingleOrDefaultAsync(m => m.OdgNaPitanjeId == id);
            if (odgNaPitanje == null)
            {
                return NotFound();
            }
            ViewData["OdabirTipaId"] = new SelectList(_context.OdabirTipas, "OdabirTipaId", "OdabirTipaId", odgNaPitanje.OdabirTipaId);
            ViewData["OdgovorId"] = new SelectList(_context.Odgovori, "OdgovorId", "TekstOdgovora", odgNaPitanje.OdgovorId);
            return View(odgNaPitanje);
        }

        // POST: OdgNaPitanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdgNaPitanjeId,OdabirTipaId,OdgovorId,Tačno,TipOdgovora")] OdgNaPitanje odgNaPitanje)
        {
            if (id != odgNaPitanje.OdgNaPitanjeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odgNaPitanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdgNaPitanjeExists(odgNaPitanje.OdgNaPitanjeId))
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
            ViewData["OdabirTipaId"] = new SelectList(_context.OdabirTipas, "OdabirTipaId", "OdabirTipaId", odgNaPitanje.OdabirTipaId);
            ViewData["OdgovorId"] = new SelectList(_context.Odgovori, "OdgovorId", "TekstOdgovora", odgNaPitanje.OdgovorId);
            return View(odgNaPitanje);
        }

        // GET: OdgNaPitanjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgNaPitanje = await _context.OdgNaPitanjes
                .Include(o => o.OdabirTipa)
                .Include(o => o.Odgovor)
                .SingleOrDefaultAsync(m => m.OdgNaPitanjeId == id);
            if (odgNaPitanje == null)
            {
                return NotFound();
            }

            return View(odgNaPitanje);
        }

        // POST: OdgNaPitanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odgNaPitanje = await _context.OdgNaPitanjes.SingleOrDefaultAsync(m => m.OdgNaPitanjeId == id);
            _context.OdgNaPitanjes.Remove(odgNaPitanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdgNaPitanjeExists(int id)
        {
            return _context.OdgNaPitanjes.Any(e => e.OdgNaPitanjeId == id);
        }
    }
}
