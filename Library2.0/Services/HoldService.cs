using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;

namespace Library.Services
{
    public class HoldService : IHold
    {
        private LibraryDbContext _context;
        public HoldService(LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(Hold hold)
        {
            _context.Add(hold);
            _context.SaveChanges();
        }

        public Hold Get(int id)
        {
            return GetAll().FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hold> GetAll()
        {
            return _context.Holds;
        }


        public void Remove(int id)
        {
            var hold = Get(id);
            _context.Remove(hold);
            _context.SaveChanges();
        }
    }
}
