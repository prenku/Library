using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IAssetType
    {
        IList<AssetType> GetAll();
        AssetType GetById(int id);
        AssetType GetByName(string assetName);
        void Add(AssetType assetType);
        void Delete(AssetType assetType);
    }
}
