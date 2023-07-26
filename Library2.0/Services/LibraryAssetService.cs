using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Models;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryDbContext _context; 
        public LibraryAssetService(LibraryDbContext context)
        {
            _context = context;       
        }
        public void Add(LibraryAsset asset)
        {
            _context.Add(asset);
            _context.SaveChanges();
        }

        public LibraryAsset Get(int assetID)
        {
            return GetAll().FirstOrDefault(a => a.Id == assetID);
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(a => a.AssetType)
                .Include(s => s.Status)
                .Include(b => b.HomeBranch)
                .Include(c => c.LibraryCard)
                .Include(h=>h.Hold)
                .Include(d=>d.Dues);
        }

        public Status GetStatusByName(string statusName)
        {
            return _context.Status.FirstOrDefault(s=>s.Name == statusName);
        }

        public IEnumerable<LibraryAsset> GetAssetByAuthor(string author)
        {
            return GetAll().OfType<Book>().Where(a => a.Author == author);
        }

        public LibraryAsset GetAssetByISBN(string isbn)
        {
            return GetAll().OfType<Book>().FirstOrDefault(i => i.ISBN.ToLower() == isbn.ToLower());
        }

        public LibraryAsset GetAssetByTitle(string title)
        {
            return GetAll().OfType<Book>().FirstOrDefault(i => i.Title.ToLower() == title.ToLower());
        }

        public IEnumerable<LibraryAsset> GetAssetByYearPublished(DateTime date)
        {
            return GetAll().Where(y => y.Year == date);
        }

        public Branch GetAssetHomeBranch(int assetID)
        {
            return Get(assetID).HomeBranch;
        }

        public AssetType GetAssetType(int assetID)
        {
            return Get(assetID).AssetType;
        }

        public double GetCost(int assetID)
        {
            return Get(assetID).Cost;
        }

        public int GetNumberOfCopies(int assetID)
        {
            return Get(assetID).Quantity;
        }

        public bool IsAssetBestSeller(int assetID)
        {
            return Get(assetID).BestSeller;
        }

        public void Remove(int id)
        {
          var asset = Get(id);
            
            _context.Update(asset);
            
            _context.Remove(asset);
            _context.SaveChanges();
        }

        public void Update(LibraryAsset asset)
        {
            var update = Get(asset.Id);
            _context.Update(update);

            update = asset;
            _context.SaveChanges();
        }

        public double GetPrice(int assetId)
        {
            return Get(assetId).Price;
        }

        public double SetPrice(int assetId, double price)
        {
            var asset = Get(assetId);

            _context.Update(asset);
            asset.Price = price;
            _context.SaveChanges();

            return price;
        }
    }
}
