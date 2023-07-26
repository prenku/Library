using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public interface IHold
    {
        Hold Get(int id);
        IEnumerable<Hold> GetAll();
        void Add(Hold hold);
        void Remove(int id);
    }
}
