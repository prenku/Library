﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Hold
    {
        public int Id { get; set; }
        public Patron Patron { get; set; }
        public  LibraryAsset Asset { get; set; }
        public DateTime HoldPlaced { get; set; }
        
    }
}
