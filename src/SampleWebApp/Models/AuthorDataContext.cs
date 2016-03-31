using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Models;

namespace SampleWebApp.Data
{
    public class AuthorDataContext : DbContext
    {
        public DbSet<Author> Author { get; set; }

        public AuthorDataContext (DbContextOptions<AuthorDataContext> options)
            : base(options)
        {
        }
    }
}
