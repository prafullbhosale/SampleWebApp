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
    public class AuthorsMvcController : Controller
    {
        private AuthorDataContext _context;

        public AuthorsMvcController(AuthorDataContext context)
        {
            _context = context;    
        }

        // GET: AuthorsMvc
        public IActionResult Index()
        {
            return View(_context.Author.ToList());
        }

        // GET: AuthorsMvc/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author author = _context.Author.SingleOrDefault(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: AuthorsMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorsMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Author.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: AuthorsMvc/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author author = _context.Author.SingleOrDefault(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: AuthorsMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Update(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: AuthorsMvc/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author author = _context.Author.SingleOrDefault(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: AuthorsMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Author author = _context.Author.SingleOrDefault(m => m.AuthorID == id);
            _context.Author.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
