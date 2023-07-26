using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Dues
    {
        public int Id { get; set; }
        public virtual Patron Patron { get; set; }
        public decimal Cost { get; set; }
        public DateTime DueSince { get; set; }

    }
}
