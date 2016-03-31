using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Data;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/AuthorssApi")]
    public class AuthorssApiController : Controller
    {
        private AuthorDataContext _context;

        public AuthorssApiController(AuthorDataContext context)
        {
            _context = context;
        }

        // GET: api/AuthorssApi
        [HttpGet]
        public IEnumerable<Author> GetAuthor()
        {
            return _context.Author;
        }

        // GET: api/AuthorssApi/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Author author = _context.Author.SingleOrDefault(m => m.AuthorID == id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/AuthorssApi/5
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, [FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.AuthorID)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/AuthorssApi
        [HttpPost]
        public IActionResult PostAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Author.Add(author);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AuthorExists(author.AuthorID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetAuthor", new { id = author.AuthorID }, author);
        }

        // DELETE: api/AuthorssApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Author author = _context.Author.SingleOrDefault(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Author.Remove(author);
            _context.SaveChanges();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorExists(int id)
        {
            return _context.Author.Count(e => e.AuthorID == id) > 0;
        }
    }
}