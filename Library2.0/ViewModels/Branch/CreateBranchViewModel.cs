using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels.Branch
{
    public class CreateBranchViewModel
    {
        public string Name { get; set; }
        public DateTime Estabilished { get; set; }
        public string Location { get; set; }
        public string Telephone { get; set; }
        public string Description {  get; set; }
        public byte Image { get; set; }
    }
}
