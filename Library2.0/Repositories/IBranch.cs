using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
   public interface IBranch
    {
        void Add(Branch branch);
        void Remove(int id);
        Branch Get(int id);
        IEnumerable<Branch> GetAll();
        IEnumerable<Patron> GetBranchPatrons(int branchId);
        IEnumerable<LibraryAsset> GetBranchAssets(int branchId);
        Branch GetBranchByName(string branchName);
        double BranchTotalCostOfSalesCopies(int branchId);
    }
}
