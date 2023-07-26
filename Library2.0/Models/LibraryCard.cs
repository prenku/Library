using System;
using System.Collections.Generic;

namespace Library.Models
{
    public class LibraryCard
    {
        public Guid Id { get; set; }
        public virtual Patron Patron { get; set; }
        
        public decimal Cost { get; set; }

        public virtual ICollection<LibraryAsset> Assets { get; set; }
    }
}