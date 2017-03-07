using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KBM.Web.Data;

namespace KBM.Web.Controllers
{
    public class UjiansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UjiansController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Ujians
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataUjian.ToListAsync());
        }

        // GET: Ujians/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ujian = await _context.DataUjian
                .SingleOrDefaultAsync(m => m.UjianId == id);
            if (ujian == null)
            {
                return NotFound();
            }

            return View(ujian);
        }

        // GET: Ujians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ujians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UjianId,Nilai,Status,Tanggal")] Ujian ujian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ujian);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ujian);
        }

        // GET: Ujians/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ujian = await _context.DataUjian.SingleOrDefaultAsync(m => m.UjianId == id);
            if (ujian == null)
            {
                return NotFound();
            }
            return View(ujian);
        }

        // POST: Ujians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UjianId,Nilai,Status,Tanggal")] Ujian ujian)
        {
            if (id != ujian.UjianId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ujian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UjianExists(ujian.UjianId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ujian);
        }

        // GET: Ujians/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ujian = await _context.DataUjian
                .SingleOrDefaultAsync(m => m.UjianId == id);
            if (ujian == null)
            {
                return NotFound();
            }

            return View(ujian);
        }

        // POST: Ujians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ujian = await _context.DataUjian.SingleOrDefaultAsync(m => m.UjianId == id);
            _context.DataUjian.Remove(ujian);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UjianExists(long id)
        {
            return _context.DataUjian.Any(e => e.UjianId == id);
        }
    }
}
