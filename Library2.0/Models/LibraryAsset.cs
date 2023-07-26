using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class LibraryAsset
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime  Year { get; set; }
        public bool BestSeller { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public virtual AssetType AssetType { get; set; }
        public virtual Status Status { get; set; }
        public virtual Branch HomeBranch { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
        public virtual Dues Dues { get; set; }
        public virtual Hold Hold { get; set; }
    }
}
