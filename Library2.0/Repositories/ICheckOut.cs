using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface ICheckOut 
    {
        CheckOut Get(int id);
        IEnumerable<CheckOut> GetAll();
        IEnumerable<CheckOutHistory> CheckOutHistory();

        void PlaceHold(int assetId, Guid catdId);
        void Add(CheckOut checkOut);
        void Remove(CheckOut checkOut);
        void Update(CheckOut checkOut);
        void MarkLost(int id);
        void MarkFound(int id);
        void CheckInItem(int id);
        void CheckOutItem(int id);        
    }
}
