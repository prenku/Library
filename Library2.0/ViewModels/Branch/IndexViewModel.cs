using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.ViewModels.Branch
{
    public class IndexViewModel
    {
        public IEnumerable<Library.Models.Branch> Branchs { get; set; }

    }
}