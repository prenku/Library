using System;
using System.Collections;
using System.Collections.Generic;

namespace Library.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string Name { get; set; }
        public DateTime Estabilished { get; set; }
        public string Location { get; set; }
        public virtual IEnumerable<Patron> Patrons { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
    }
}