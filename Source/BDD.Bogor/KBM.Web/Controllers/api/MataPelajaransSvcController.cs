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
    [Route("api/MataPelajaransSvc")]
    public class MataPelajaransSvcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MataPelajaransSvcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MataPelajaransSvc
        [HttpGet]
        public IEnumerable<MataPelajaran> GetDataPelajaran()
        {
            return _context.DataPelajaran;
        }

        // GET: api/MataPelajaransSvc/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMataPelajaran([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mataPelajaran = await _context.DataPelajaran.SingleOrDefaultAsync(m => m.MataPelajaranId == id);

            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return Ok(mataPelajaran);
        }

        // PUT: api/MataPelajaransSvc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMataPelajaran([FromRoute] long id, [FromBody] MataPelajaran mataPelajaran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mataPelajaran.MataPelajaranId)
            {
                return BadRequest();
            }

            _context.Entry(mataPelajaran).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MataPelajaranExists(id))
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

        // POST: api/MataPelajaransSvc
        [HttpPost]
        public async Task<IActionResult> PostMataPelajaran([FromBody] MataPelajaran mataPelajaran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataPelajaran.Add(mataPelajaran);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MataPelajaranExists(mataPelajaran.MataPelajaranId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMataPelajaran", new { id = mataPelajaran.MataPelajaranId }, mataPelajaran);
        }

        // DELETE: api/MataPelajaransSvc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMataPelajaran([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mataPelajaran = await _context.DataPelajaran.SingleOrDefaultAsync(m => m.MataPelajaranId == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            _context.DataPelajaran.Remove(mataPelajaran);
            await _context.SaveChangesAsync();

            return Ok(mataPelajaran);
        }

        private bool MataPelajaranExists(long id)
        {
            return _context.DataPelajaran.Any(e => e.MataPelajaranId == id);
        }
    }
}