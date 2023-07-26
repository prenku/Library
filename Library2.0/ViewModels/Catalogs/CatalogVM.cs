using Library.Models;
using System.Collections.Generic;

namespace Library.ViewModels.Catalogs
{

    public class IndexViewModel
    {
        public IEnumerable<LibraryAsset> LibraryAsset { get; set; }
    }
}
