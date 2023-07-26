using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface ILibraryAsset
    {
        LibraryAsset Get(int assetID);
        IEnumerable<LibraryAsset> GetAll();
        Status GetStatusByName(string statusName);
        Branch GetAssetHomeBranch(int assetID);
        AssetType GetAssetType(int assetID);

        IEnumerable<LibraryAsset> GetAssetByAuthor(string author);
        LibraryAsset GetAssetByTitle(string title);
        IEnumerable<LibraryAsset> GetAssetByYearPublished(DateTime date);
        LibraryAsset GetAssetByISBN(string isbn);

        int GetNumberOfCopies(int assetID);
        double GetCost(int assetID);
        double GetPrice(int assetId);
        double SetPrice(int assetId,double price);
        bool IsAssetBestSeller(int assetID);
        void Add(LibraryAsset asset);
        void Update(LibraryAsset asset);
        void Remove(int id);
    }
}
