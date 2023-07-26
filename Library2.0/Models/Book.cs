using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book : LibraryAsset
    {
        
        public string Author { get; set; }
        public string ISBN { get; set; }
        public byte Image { get; set; }
    }
}
