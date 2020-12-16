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
    public class PelanggansController : Controller
    {
        private readonly cafetariaContext _context;

        public PelanggansController(cafetariaContext context)
        {
            _context = context;
        }

        // GET: Pelanggans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pelanggan.ToListAsync());
        }

        // GET: Pelanggans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggan = await _context.Pelanggan
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (pelanggan == null)
            {
                return NotFound();
            }

            return View(pelanggan);
        }

        // GET: Pelanggans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pelanggans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelanggan,Nama,JenisKelamin")] Pelanggan pelanggan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelanggan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelanggan);
        }

        // GET: Pelanggans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggan = await _context.Pelanggan.FindAsync(id);
            if (pelanggan == null)
            {
                return NotFound();
            }
            return View(pelanggan);
        }

        // POST: Pelanggans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelanggan,Nama,JenisKelamin")] Pelanggan pelanggan)
        {
            if (id != pelanggan.IdPelanggan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelanggan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelangganExists(pelanggan.IdPelanggan))
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
            return View(pelanggan);
        }

        // GET: Pelanggans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggan = await _context.Pelanggan
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (pelanggan == null)
            {
                return NotFound();
            }

            return View(pelanggan);
        }

        // POST: Pelanggans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelanggan = await _context.Pelanggan.FindAsync(id);
            _context.Pelanggan.Remove(pelanggan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelangganExists(int id)
        {
            return _context.Pelanggan.Any(e => e.IdPelanggan == id);
        }
    }
}
