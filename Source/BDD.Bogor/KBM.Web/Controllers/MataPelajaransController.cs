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
    public class MataPelajaransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MataPelajaransController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MataPelajarans
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataPelajaran.ToListAsync());
        }

        // GET: MataPelajarans/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.DataPelajaran
                .SingleOrDefaultAsync(m => m.MataPelajaranId == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return View(mataPelajaran);
        }

        // GET: MataPelajarans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MataPelajarans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MataPelajaranId,Nama,Penyusun")] MataPelajaran mataPelajaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mataPelajaran);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mataPelajaran);
        }

        // GET: MataPelajarans/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.DataPelajaran.SingleOrDefaultAsync(m => m.MataPelajaranId == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }
            return View(mataPelajaran);
        }

        // POST: MataPelajarans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MataPelajaranId,Nama,Penyusun")] MataPelajaran mataPelajaran)
        {
            if (id != mataPelajaran.MataPelajaranId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mataPelajaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MataPelajaranExists(mataPelajaran.MataPelajaranId))
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
            return View(mataPelajaran);
        }

        // GET: MataPelajarans/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.DataPelajaran
                .SingleOrDefaultAsync(m => m.MataPelajaranId == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return View(mataPelajaran);
        }

        // POST: MataPelajarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mataPelajaran = await _context.DataPelajaran.SingleOrDefaultAsync(m => m.MataPelajaranId == id);
            _context.DataPelajaran.Remove(mataPelajaran);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MataPelajaranExists(long id)
        {
            return _context.DataPelajaran.Any(e => e.MataPelajaranId == id);
        }
    }
}
