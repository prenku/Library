using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels.Catalogs
{

    [NotMapped]
    public class AddAssetViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public bool BestSeller { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int Quantity { get; set; }

        public IEnumerable<SelectListItem> AssetType { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public IEnumerable<SelectListItem> HomeBranch { get; set; }
        public IEnumerable<SelectListItem> LibraryCard { get; set; }
    }
}
