using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Interfaces;
using System;
using Library.Data;
using System.Collections.Generic;
using System.Linq;
using Library.Repositories;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private LibraryDbContext _context;
        private ILibraryAsset _asset;
        private IPatron _patron;
        private IBranch _branch;
        private IRepository _repository;
        public HomeController( LibraryDbContext context,
            ILibraryAsset asset , IPatron patron , IBranch branch , IRepository repository)
        {
            _context = context;
            _asset = asset;
            _patron = patron;
            _branch = branch;
            _repository = repository; 
        }
        public IActionResult Index()
        {
            ViewBag.NumberOfAssets = _asset.GetAll().Count();
            ViewBag.NumberOfPatrons = _patron.GetAll().Count();
            ViewBag.NumberOfBranches = _branch.GetAll().Count();

            return View();
        }

        public string Repo()
        {
            var libraryAsset = _repository.LibraryAssetService;

            var libraryCard = _repository.LibraryCardService;
            var asset = new LibraryAsset { AssetType = new AssetType(), HomeBranch = new Branch(), BestSeller = false, Cost = 10.99, Price = 17.99, Status = new Status(), Title = "this asset was added via repo action", Quantity = 99, LibraryCard = new LibraryCard(), ImageUrl = string.Empty, Year = DateTime.Now };

            libraryAsset.Add(asset);
            return asset.Title.ToString();
        }
            

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
