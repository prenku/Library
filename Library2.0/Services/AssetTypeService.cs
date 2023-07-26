using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Services
{
    public class AssetTypeService : IAssetType
    {
        private LibraryDbContext _context;
        public AssetTypeService(LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(AssetType assetType)
        {
            _context.Add(assetType);
            _context.SaveChanges();

        }
        public void Delete(AssetType assetType)
        {
            _context.Remove(assetType);
            _context.SaveChanges();
        }

        public IList<AssetType> GetAll()
        {
            return _context.AssetType.ToList();
        }

        public AssetType GetById(int assetId)
        {
            return GetAll().FirstOrDefault(a => a.Id == assetId);
        }

        public AssetType GetByName(string assetName)
        {
            return GetAll().FirstOrDefault(n => n.Name == assetName);
        }
    } 
}
