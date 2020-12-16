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
    public class MemilihsController : Controller
    {
        private readonly cafetariaContext _context;

        public MemilihsController(cafetariaContext context)
        {
            _context = context;
        }

        // GET: Memilihs
        public async Task<IActionResult> Index()
        {
            var cafetariaContext = _context.Memilih.Include(m => m.IdMenuNavigation).Include(m => m.IdPelangganNavigation);
            return View(await cafetariaContext.ToListAsync());
        }

        // GET: Memilihs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memilih = await _context.Memilih
                .Include(m => m.IdMenuNavigation)
                .Include(m => m.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdMemilih == id);
            if (memilih == null)
            {
                return NotFound();
            }

            return View(memilih);
        }

        // GET: Memilihs/Create
        public IActionResult Create()
        {
            ViewData["IdMenu"] = new SelectList(_context.Menu, "IdMenu", "IdMenu");
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan");
            return View();
        }

        // POST: Memilihs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMemilih,IdMenu,IdPelanggan,JumlahPesanan")] Memilih memilih)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memilih);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMenu"] = new SelectList(_context.Menu, "IdMenu", "IdMenu", memilih.IdMenu);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", memilih.IdPelanggan);
            return View(memilih);
        }

        // GET: Memilihs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memilih = await _context.Memilih.FindAsync(id);
            if (memilih == null)
            {
                return NotFound();
            }
            ViewData["IdMenu"] = new SelectList(_context.Menu, "IdMenu", "IdMenu", memilih.IdMenu);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", memilih.IdPelanggan);
            return View(memilih);
        }

        // POST: Memilihs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMemilih,IdMenu,IdPelanggan,JumlahPesanan")] Memilih memilih)
        {
            if (id != memilih.IdMemilih)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memilih);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemilihExists(memilih.IdMemilih))
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
            ViewData["IdMenu"] = new SelectList(_context.Menu, "IdMenu", "IdMenu", memilih.IdMenu);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", memilih.IdPelanggan);
            return View(memilih);
        }

        // GET: Memilihs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memilih = await _context.Memilih
                .Include(m => m.IdMenuNavigation)
                .Include(m => m.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdMemilih == id);
            if (memilih == null)
            {
                return NotFound();
            }

            return View(memilih);
        }

        // POST: Memilihs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memilih = await _context.Memilih.FindAsync(id);
            _context.Memilih.Remove(memilih);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemilihExists(int id)
        {
            return _context.Memilih.Any(e => e.IdMemilih == id);
        }
    }
}
