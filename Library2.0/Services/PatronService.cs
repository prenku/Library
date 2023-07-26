using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.Data;

namespace Library.Services
{
    public class PatronService : IPatron
    {
        private LibraryDbContext _context;
        public PatronService(LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(Patron patron)
        {
            _context.Patrons.Add(patron);
            _context.SaveChanges();
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons.Include(a =>a.LibraryCard).Include(b=>b.HomeBrach);
        }

        public Patron Get(int patronId)
        {
            return GetAll()
                .FirstOrDefault(patron => patron.PatronID == patronId);
        }

        public IEnumerable<Dues> GetDues(int patronId)
        {
            return _context.Dues.Where(p => p.Patron.PatronID == patronId).ToList();

        }

        public IEnumerable<Hold> GetHolds(int patronId)
        {
            return _context.Holds.Where(p => p.Patron.PatronID == patronId).ToList();
        }

        public bool HasDues(int patronId)
        {
            var patron = Get(patronId);// GetAll().FirstOrDefault(p=>p.PatronID == patronId);
            var dues = _context.Dues.Where(p => p.Patron == patron).Any();
            return dues;
        }

        public bool HasHolds(int patronId)
        {
            var patron = Get(patronId);// GetAll().FirstOrDefault(p=>p.PatronID == patronId);
            var holds = _context.Holds.Where(p => p.Patron == patron).Any();
            return holds;
        }

        public bool IsLocked(int patronId)
        {
            return (bool)Get(patronId).Locked;
        }

        public void Remove(Patron patron)
        {
            _context.Remove(patron);
            _context.SaveChanges();
        }

        public void Update(Patron patron)
        {
            var updatePatron = Get(patron.PatronID);
            _context.Update(patron);

            updatePatron = patron;
            _context.SaveChanges();
        }

        public IEnumerable<CheckOutHistory> GetCheckOutHistory(int patronId)
        {
            var cardId = _context.Patrons
               .Include(a => a.LibraryCard)
               .FirstOrDefault(a => a.PatronID == patronId)
               .LibraryCard.Id;

            return _context.CheckOutHistories
                .Include(a => a.LibraryCard)
                .Include(a => a.LibraryAsset)
                .Where(a => a.LibraryCard.Id == cardId)
                .OrderByDescending(a => a.CheckedOut);
        }
    }
}
