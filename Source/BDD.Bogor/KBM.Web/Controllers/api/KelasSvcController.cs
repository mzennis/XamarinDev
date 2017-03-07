using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBM.Web.Data;

namespace KBM.Web.Controllers.api
{
    [Produces("application/json")]
    [Route("api/KelasSvc")]
    public class KelasSvcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KelasSvcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KelasSvc
        [HttpGet]
        public IEnumerable<Kelas> GetDataKelas()
        {
            return _context.DataKelas;
        }

        // GET: api/KelasSvc/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKelas([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kelas = await _context.DataKelas.SingleOrDefaultAsync(m => m.KelasId == id);

            if (kelas == null)
            {
                return NotFound();
            }

            return Ok(kelas);
        }

        // PUT: api/KelasSvc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKelas([FromRoute] long id, [FromBody] Kelas kelas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kelas.KelasId)
            {
                return BadRequest();
            }

            _context.Entry(kelas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KelasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/KelasSvc
        [HttpPost]
        public async Task<IActionResult> PostKelas([FromBody] Kelas kelas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataKelas.Add(kelas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KelasExists(kelas.KelasId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKelas", new { id = kelas.KelasId }, kelas);
        }

        // DELETE: api/KelasSvc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKelas([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kelas = await _context.DataKelas.SingleOrDefaultAsync(m => m.KelasId == id);
            if (kelas == null)
            {
                return NotFound();
            }

            _context.DataKelas.Remove(kelas);
            await _context.SaveChangesAsync();

            return Ok(kelas);
        }

        private bool KelasExists(long id)
        {
            return _context.DataKelas.Any(e => e.KelasId == id);
        }
    }
}