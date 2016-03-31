using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SampleWebApp.Data;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class BooksMvcController : Controller
    {
        private BookDataContext _context;

        public BooksMvcController(BookDataContext context)
        {
            _context = context;    
        }

        // GET: BooksMvc
        public IActionResult Index()
        {
            var bookDataContext = _context.Book.Include(b => b.Author);
            return View(bookDataContext.ToList());
        }

        // GET: BooksMvc/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = _context.Book.SingleOrDefault(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: BooksMvc/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "Author");
            return View();
        }

        // POST: BooksMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "Author", book.AuthorID);
            return View(book);
        }

        // GET: BooksMvc/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = _context.Book.SingleOrDefault(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "Author", book.AuthorID);
            return View(book);
        }

        // POST: BooksMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "Author", book.AuthorID);
            return View(book);
        }

        // GET: BooksMvc/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = _context.Book.SingleOrDefault(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BooksMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Book book = _context.Book.SingleOrDefault(m => m.BookID == id);
            _context.Book.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
