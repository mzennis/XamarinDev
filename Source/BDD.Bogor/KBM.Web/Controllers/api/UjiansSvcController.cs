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
    [Route("api/UjiansSvc")]
    public class UjiansSvcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UjiansSvcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UjiansSvc
        [HttpGet]
        public IEnumerable<Ujian> GetDataUjian()
        {
            return _context.DataUjian;
        }

        // GET: api/UjiansSvc/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUjian([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ujian = await _context.DataUjian.SingleOrDefaultAsync(m => m.UjianId == id);

            if (ujian == null)
            {
                return NotFound();
            }

            return Ok(ujian);
        }

        // PUT: api/UjiansSvc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUjian([FromRoute] long id, [FromBody] Ujian ujian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ujian.UjianId)
            {
                return BadRequest();
            }

            _context.Entry(ujian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UjianExists(id))
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

        // POST: api/UjiansSvc
        [HttpPost]
        public async Task<IActionResult> PostUjian([FromBody] Ujian ujian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataUjian.Add(ujian);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UjianExists(ujian.UjianId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUjian", new { id = ujian.UjianId }, ujian);
        }

        // DELETE: api/UjiansSvc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUjian([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ujian = await _context.DataUjian.SingleOrDefaultAsync(m => m.UjianId == id);
            if (ujian == null)
            {
                return NotFound();
            }

            _context.DataUjian.Remove(ujian);
            await _context.SaveChangesAsync();

            return Ok(ujian);
        }

        private bool UjianExists(long id)
        {
            return _context.DataUjian.Any(e => e.UjianId == id);
        }
    }
}