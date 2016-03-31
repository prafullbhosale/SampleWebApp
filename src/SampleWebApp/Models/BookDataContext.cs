using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Models;

namespace SampleWebApp.Data
{
    public class BookDataContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public BookDataContext (DbContextOptions<BookDataContext> options)
            : base(options)
        {
        }
    }
}
