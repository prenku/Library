using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IBook 
    {
        IEnumerable<Book> GetAll();
        Book Get(int bookId);
        
        void Add(Book book);
        void Remove(Book book);
    }

}
