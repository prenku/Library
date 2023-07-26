using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CheckOut
    {
        public int Id { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
        public DateTime? ReturnedOn { get; set; }

        public virtual LibraryAsset LibraryAsset { get; set; }
        public virtual LibraryCard Card { get; set; }
    }
}
