using Library.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using System;
using Library.Data;

namespace Library.Services
{
    public class BranchService : IBranch
    {
        private LibraryDbContext _context;

        public BranchService(LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(Branch branch)
        {
            _context.Add(branch);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetBranchAssets(int branchId)
        {
            return _context.LibraryAssets.Where(b => b.HomeBranch.BranchID == branchId);
        }

        public Branch GetBranchByName(string branchName)
        {
           return _context.Branches.FirstOrDefault(b => b.Name.ToLower() == branchName);
        }

        public double BranchTotalCostOfSalesCopies(int branchId)
        {
            return _context.LibraryAssets
                .Where(b => b.HomeBranch.BranchID == branchId)
                .Select(c=>c.Cost).Sum();
        }

        public Branch Get(int id)
        {
            return GetAll().FirstOrDefault(b => b.BranchID == id);
        }

        public IEnumerable<Branch> GetAll()
        {
            return _context.Branches;
        }

        public IEnumerable<Patron> GetBranchPatrons(int branchId)
        {
            return _context.Patrons.Where(b => b.HomeBrach.BranchID == branchId);
        }

        public void Remove(int id)
        {
            var branch = Get(id);
            var branchAssets = GetBranchAssets(id);

            //foreach (var asset in branchAssets)
            //{
            //    _context.Update(asset.HomeBranch);
            //    asset.HomeBranch=  Get(1);
            //}

            //_context.SaveChanges();

            _context.Remove(branch);

            _context.SaveChanges();

        }
    }
}