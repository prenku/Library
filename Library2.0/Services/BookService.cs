using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBook
    {
        private LibraryDbContext _context;
        public BookService(LibraryDbContext ctx)
        {
            _context = ctx;
        }

        public void Add(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public Book Get(int bookId)
        {
            return GetAll().FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                .Include(b=>b.HomeBranch)
                .Include(b=>b.Status)
                .Include(b=>b.AssetType);
        }

        public void Remove(Book book)
        {
           _context.Remove(book);
            _context.SaveChanges();
        }
    }
}
