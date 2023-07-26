using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;

namespace Library.Services
{
    public class LibraryCardService : ILibraryCard
    {
        private LibraryDbContext _context;
        public LibraryCardService( LibraryDbContext context)
        {
            _context = context;
        }
        public LibraryCard GetCard(Guid cardId)
        {
            return _context.LibraryCards.FirstOrDefault(c=>c.Id == cardId);
        }
    }
}
