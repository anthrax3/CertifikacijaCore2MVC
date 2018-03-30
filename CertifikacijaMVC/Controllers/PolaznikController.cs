using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CertifikacijaMVC.Data;
using CertifikacijaMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertifikacijaMVC.Controllers
{
    [Authorize]
    public class PolaznikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PolaznikController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Uvod Polaznik
        public async Task<IActionResult> Uvod()
        {
            return View(await _context.TipPolaganja.ToListAsync());
        }

        public IActionResult PocetakTesta()
        {
            return View();
        }

        // POST: TipPolaganjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PocetakTesta([Bind("TipPolaganjaId,Tip")] TipPolaganja tipPolaganja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipPolaganja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Uvod));
            }
            return View(tipPolaganja);
        }


        private bool PolaznikExists(int id)
        {
            return _context.TipPolaganja.Any(e => e.TipPolaganjaId == id);
        }
    }
}