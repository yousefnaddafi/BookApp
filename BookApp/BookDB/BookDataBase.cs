using BookApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.BookDB
{
    public class BookDataBase : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public BookDataBase(DbContextOptions<BookDataBase> options) : base(options)
        {

        }
        public BookDataBase()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(x => x.ToTable("Book"));
            modelBuilder.Entity<Author>(x => x.ToTable("Author"));
            modelBuilder.Entity<Category>(x => x.ToTable("Category"));
        }
    }
}
