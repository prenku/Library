using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels.Catalogs
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public bool BestSeller { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public string  AssetType { get; set; }
        public string  Status  { get; set; }
        public string  HomeBranch { get; set; }

    }
}
