using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;

namespace BookStore.Models
{
    public class BookDBContext:DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options): base(options)
        {

        }

        public DbSet<Book> book  { get; set; }
        public DbSet<Language> language  { get; set; }
    }
}
