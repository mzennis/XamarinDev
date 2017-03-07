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
    public class UserProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProfilesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UserProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataUser.ToListAsync());
        }

        // GET: UserProfiles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.DataUser
                .SingleOrDefaultAsync(m => m.UserId == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Nama,TanggalLahir,Kategori,Telepon,Alamat,Email,Kelompok")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.DataUser.SingleOrDefaultAsync(m => m.UserId == id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UserId,UserName,Nama,TanggalLahir,Kategori,Telepon,Alamat,Email,Kelompok")] UserProfile userProfile)
        {
            if (id != userProfile.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.UserId))
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
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.DataUser
                .SingleOrDefaultAsync(m => m.UserId == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userProfile = await _context.DataUser.SingleOrDefaultAsync(m => m.UserId == id);
            _context.DataUser.Remove(userProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserProfileExists(long id)
        {
            return _context.DataUser.Any(e => e.UserId == id);
        }
    }
}
