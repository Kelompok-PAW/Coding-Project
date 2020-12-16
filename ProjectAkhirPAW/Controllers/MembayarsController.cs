using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAkhirPAW.Models;

namespace ProjectAkhirPAW.Controllers
{
    public class MembayarsController : Controller
    {
        private readonly cafetariaContext _context;

        public MembayarsController(cafetariaContext context)
        {
            _context = context;
        }

        // GET: Membayars
        public async Task<IActionResult> Index()
        {
            var cafetariaContext = _context.Membayar.Include(m => m.IdKasirNavigation).Include(m => m.IdPelangganNavigation);
            return View(await cafetariaContext.ToListAsync());
        }

        // GET: Membayars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membayar = await _context.Membayar
                .Include(m => m.IdKasirNavigation)
                .Include(m => m.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (membayar == null)
            {
                return NotFound();
            }

            return View(membayar);
        }

        // GET: Membayars/Create
        public IActionResult Create()
        {
            ViewData["IdKasir"] = new SelectList(_context.Kasir, "IdKasir", "IdKasir");
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan");
            return View();
        }

        // POST: Membayars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,NotaPembayaran,IdKasir,IdPelanggan")] Membayar membayar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membayar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKasir"] = new SelectList(_context.Kasir, "IdKasir", "IdKasir", membayar.IdKasir);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", membayar.IdPelanggan);
            return View(membayar);
        }

        // GET: Membayars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membayar = await _context.Membayar.FindAsync(id);
            if (membayar == null)
            {
                return NotFound();
            }
            ViewData["IdKasir"] = new SelectList(_context.Kasir, "IdKasir", "IdKasir", membayar.IdKasir);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", membayar.IdPelanggan);
            return View(membayar);
        }

        // POST: Membayars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksi,NotaPembayaran,IdKasir,IdPelanggan")] Membayar membayar)
        {
            if (id != membayar.IdTransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membayar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembayarExists(membayar.IdTransaksi))
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
            ViewData["IdKasir"] = new SelectList(_context.Kasir, "IdKasir", "IdKasir", membayar.IdKasir);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", membayar.IdPelanggan);
            return View(membayar);
        }

        // GET: Membayars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membayar = await _context.Membayar
                .Include(m => m.IdKasirNavigation)
                .Include(m => m.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (membayar == null)
            {
                return NotFound();
            }

            return View(membayar);
        }

        // POST: Membayars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membayar = await _context.Membayar.FindAsync(id);
            _context.Membayar.Remove(membayar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembayarExists(int id)
        {
            return _context.Membayar.Any(e => e.IdTransaksi == id);
        }
    }
}
