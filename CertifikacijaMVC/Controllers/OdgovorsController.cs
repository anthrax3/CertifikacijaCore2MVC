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
    public class OdgovorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdgovorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Odgovors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Odgovori.ToListAsync());
        }

        // GET: Odgovors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovor = await _context.Odgovori
                .SingleOrDefaultAsync(m => m.OdgovorId == id);
            if (odgovor == null)
            {
                return NotFound();
            }

            return View(odgovor);
        }

        // GET: Odgovors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odgovors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdgovorId,TekstOdgovora")] Odgovor odgovor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odgovor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odgovor);
        }

        // GET: Odgovors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovor = await _context.Odgovori.SingleOrDefaultAsync(m => m.OdgovorId == id);
            if (odgovor == null)
            {
                return NotFound();
            }
            return View(odgovor);
        }

        // POST: Odgovors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdgovorId,TekstOdgovora")] Odgovor odgovor)
        {
            if (id != odgovor.OdgovorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odgovor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdgovorExists(odgovor.OdgovorId))
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
            return View(odgovor);
        }

        // GET: Odgovors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovor = await _context.Odgovori
                .SingleOrDefaultAsync(m => m.OdgovorId == id);
            if (odgovor == null)
            {
                return NotFound();
            }

            return View(odgovor);
        }

        // POST: Odgovors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odgovor = await _context.Odgovori.SingleOrDefaultAsync(m => m.OdgovorId == id);
            _context.Odgovori.Remove(odgovor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdgovorExists(int id)
        {
            return _context.Odgovori.Any(e => e.OdgovorId == id);
        }
    }
}
