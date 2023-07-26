using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Repositories;
using Library.Interfaces;
using Library.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    public class Repo : Controller
    {
        private IRepository _repository;
        public Repo(IRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        public string Index()
        {
            var id = _repository.LibraryAssetService.Get(1).LibraryCard.Id;
            return _repository.LibraryCardService.GetCard(id).Id.ToString();
        }
        public IActionResult Hold()
        {
            var hold = new Hold { Asset = new LibraryAsset(), HoldPlaced = DateTime.Now, Patron = new
                 Patron() };
           _repository.HoldService.Add(hold);

            return Content(_repository.HoldService.Get(hold.Id).HoldPlaced.ToString());
        }
    }
}
