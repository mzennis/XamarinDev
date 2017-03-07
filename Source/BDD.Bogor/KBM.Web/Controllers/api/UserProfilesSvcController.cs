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
    [Route("api/UserProfilesSvc")]
    public class UserProfilesSvcController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProfilesSvcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserProfilesSvc
        //[HttpGet("[action]")] - another way
        [HttpGet]
        public IEnumerable<UserProfile> GetDataUser()
        {
            return _context.DataUser;
        }

        // GET: api/UserProfilesSvc/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfile = await _context.DataUser.SingleOrDefaultAsync(m => m.UserId == id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        // PUT: api/UserProfilesSvc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile([FromRoute] long id, [FromBody] UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
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

        // POST: api/UserProfilesSvc
        [HttpPost]
        public async Task<IActionResult> PostUserProfile([FromBody] UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataUser.Add(userProfile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserProfileExists(userProfile.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserProfile", new { id = userProfile.UserId }, userProfile);
        }

        // DELETE: api/UserProfilesSvc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfile = await _context.DataUser.SingleOrDefaultAsync(m => m.UserId == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            _context.DataUser.Remove(userProfile);
            await _context.SaveChangesAsync();

            return Ok(userProfile);
        }

        private bool UserProfileExists(long id)
        {
            return _context.DataUser.Any(e => e.UserId == id);
        }
    }
}