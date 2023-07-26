using Library.Data;
using Library.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;
using Library.ViewModels.Catalogs;
using Library.Repositories;

namespace Library.Controllers
{
    public class CatalogsController : Controller
    {
        private ILibraryAsset _asset;
        private IAssetType _assetType;
        private LibraryDbContext _context;
        private ILibraryCard _libraryCard;
        private IHold _hold;
        private ICheckOut _checkOut;
        private IBranch _branch;
        //private IRepository _repository;
        
        public CatalogsController(ILibraryAsset asset , IAssetType assetType,
            LibraryDbContext context, ILibraryCard libraryCard ,ICheckOut checkOut, IHold hold , IBranch  branch)
        {
            _asset = asset; _context = context;  _assetType = assetType;
            _libraryCard = libraryCard; _hold = hold; _checkOut = checkOut;
            _branch = branch;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                LibraryAsset = _asset.GetAll()
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult AddAsset()
        {
           //var cardid= _repository.ILibraryCard.GetCard(new Guid());
            var assetType = _assetType.GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            var status = _context.Status
                .Select(s => new SelectListItem { Text = s.Name, Value = s.Name.ToString() }).AsEnumerable();

            var branches = _branch.GetAll().Select(b => new SelectListItem { Text = b.Name, Value = b.BranchID.ToString() }).AsEnumerable();

            return View(new AddAssetViewModel { Year = DateTime.UtcNow , AssetType = assetType, BestSeller = false , Status = status.ToList() , HomeBranch = branches.ToList() } );
        }
     
        [HttpPost]
        public IActionResult AddAsset(AddAssetViewModel model,string AssetType, string Status, string HomeBranch)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", errorMessage: "There is an error in the entered data");
                return View(model);
            }
            
            LibraryAsset asset = new LibraryAsset();

            asset.Cost = model.Cost;
            asset.BestSeller = model.BestSeller;
            asset.HomeBranch = _branch.Get(Convert.ToInt32(HomeBranch));
            asset.Quantity = model.Quantity;
            asset.Status = _asset.GetStatusByName(Status);
            asset.LibraryCard = new LibraryCard();
            asset.Title = model.Title;
            asset.Year = model.Year;
            asset.AssetType = _assetType.GetById(Convert.ToInt32(AssetType));

            _asset.Add(asset);
           
            return RedirectToAction("Index");
        }       
        public IActionResult Delete(int id)
        {
            var asset = _asset.Get(id);

            _asset.Remove(asset.Id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult PlaceHold(Guid cartId , int assetId)
        {
            var libraryCard = _libraryCard.GetCard(cartId);
            var libraryAsset = _asset.Get(assetId);

            var hold = new Hold
            {
                Asset = libraryAsset,
                HoldPlaced = DateTime.Now,
                Patron = new Patron()
            };
            _hold.Add(hold);

            _checkOut.PlaceHold(libraryAsset.Id, libraryCard.Id);
            return RedirectToAction("Details", new { id = assetId });
        }

        public IActionResult Details(int id)
        {
            var asset = _asset.Get(id);
            var model = new DetailsViewModel
            {
                Status = asset.Status.Name,
                Title = asset.Title,
                ImageUrl = asset.ImageUrl,
                AssetType = asset.AssetType.Name,
                BestSeller = asset.BestSeller,
                HomeBranch = asset.HomeBranch.Name,
                Price = asset.Price,
                Quantity = asset.Quantity,
                Year = asset.Year,
            };
            return View(model);
        }
     }
}