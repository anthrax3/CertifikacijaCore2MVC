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
    public class PitanjesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PitanjesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pitanjes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pitanja.ToListAsync());
        }

        // GET: Pitanjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanje = await _context.Pitanja
                .SingleOrDefaultAsync(m => m.PitanjeId == id);
            if (pitanje == null)
            {
                return NotFound();
            }

            return View(pitanje);
        }

        // GET: Pitanjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pitanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PitanjeId,TekstPitanja")] Pitanje pitanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pitanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pitanje);
        }

        // GET: Pitanjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanje = await _context.Pitanja.SingleOrDefaultAsync(m => m.PitanjeId == id);
            if (pitanje == null)
            {
                return NotFound();
            }
            return View(pitanje);
        }

        // POST: Pitanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PitanjeId,TekstPitanja")] Pitanje pitanje)
        {
            if (id != pitanje.PitanjeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pitanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PitanjeExists(pitanje.PitanjeId))
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
            return View(pitanje);
        }

        // GET: Pitanjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanje = await _context.Pitanja
                .SingleOrDefaultAsync(m => m.PitanjeId == id);
            if (pitanje == null)
            {
                return NotFound();
            }

            return View(pitanje);
        }

        // POST: Pitanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pitanje = await _context.Pitanja.SingleOrDefaultAsync(m => m.PitanjeId == id);
            _context.Pitanja.Remove(pitanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PitanjeExists(int id)
        {
            return _context.Pitanja.Any(e => e.PitanjeId == id);
        }
    }
}
