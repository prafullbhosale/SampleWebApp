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
    [Route("api/BooksApi")]
    public class BooksApiController : Controller
    {
        private BookDataContext _context;

        public BooksApiController(BookDataContext context)
        {
            _context = context;
        }

        // GET: api/BooksApi
        [HttpGet]
        public IEnumerable<Book> GetBook()
        {
            return _context.Book;
        }

        // GET: api/BooksApi/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = _context.Book.SingleOrDefault(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/BooksApi/5
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BookID)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/BooksApi
        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Book.Add(book);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BookExists(book.BookID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetBook", new { id = book.BookID }, book);
        }

        // DELETE: api/BooksApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = _context.Book.SingleOrDefault(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            _context.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return _context.Book.Count(e => e.BookID == id) > 0;
        }
    }
}