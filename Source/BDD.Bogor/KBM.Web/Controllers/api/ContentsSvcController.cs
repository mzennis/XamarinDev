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
    [Route("api/ContentsSvc")]
    public class ContentsSvcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentsSvcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContentsSvc
        [HttpGet]
        public IEnumerable<Content> GetDataContent()
        {
            return _context.DataContent;
        }

        // GET: api/ContentsSvc/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContent([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var content = await _context.DataContent.SingleOrDefaultAsync(m => m.ContentId == id);

            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }

        // PUT: api/ContentsSvc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContent([FromRoute] long id, [FromBody] Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != content.ContentId)
            {
                return BadRequest();
            }

            _context.Entry(content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
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

        // POST: api/ContentsSvc
        [HttpPost]
        public async Task<IActionResult> PostContent([FromBody] Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataContent.Add(content);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContentExists(content.ContentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContent", new { id = content.ContentId }, content);
        }

        // DELETE: api/ContentsSvc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var content = await _context.DataContent.SingleOrDefaultAsync(m => m.ContentId == id);
            if (content == null)
            {
                return NotFound();
            }

            _context.DataContent.Remove(content);
            await _context.SaveChangesAsync();

            return Ok(content);
        }

        private bool ContentExists(long id)
        {
            return _context.DataContent.Any(e => e.ContentId == id);
        }
    }
}