using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels.Patrons
{
    public class PatronsIndexViewModel
    {
        public IEnumerable<Patron> Patrons { get; set; }
    }
}
