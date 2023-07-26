using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
   public interface IPatron
    {
        void Add(Patron patron);
        void Update(Patron patronId);
        void Remove(Patron patron);
        bool IsLocked(int patronId);
        bool HasDues(int patronId);
        bool HasHolds(int patronId);

        Patron Get(int patronId);
        IEnumerable<Patron> GetAll();
        IEnumerable<CheckOutHistory> GetCheckOutHistory(int patronId);

        IEnumerable<Hold> GetHolds(int patronId);
        IEnumerable<Dues> GetDues(int patronId);
    }

}
