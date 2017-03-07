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
    public class ContentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Contents
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataContent.ToListAsync());
        }

        // GET: Contents/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.DataContent
                .SingleOrDefaultAsync(m => m.ContentId == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // GET: Contents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContentId,Judul,Konten,Links,Dokumen,Tags,Kategori")] Content content)
        {
            if (ModelState.IsValid)
            {
                _context.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(content);
        }

        // GET: Contents/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.DataContent.SingleOrDefaultAsync(m => m.ContentId == id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // POST: Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ContentId,Judul,Konten,Links,Dokumen,Tags,Kategori")] Content content)
        {
            if (id != content.ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.ContentId))
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
            return View(content);
        }

        // GET: Contents/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.DataContent
                .SingleOrDefaultAsync(m => m.ContentId == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var content = await _context.DataContent.SingleOrDefaultAsync(m => m.ContentId == id);
            _context.DataContent.Remove(content);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContentExists(long id)
        {
            return _context.DataContent.Any(e => e.ContentId == id);
        }
    }
}
