using System;
using System.Collections.Generic;
using System.Linq;
using Library.Interfaces;
using Library.Models;
using Library.Data;
using System.Linq.Expressions;
using Library.Repositories;

namespace Library.Services
{
    public class CheckOutService : ICheckOut
    {
        private LibraryDbContext _context;
        private ILibraryAsset _asset;
        private ILibraryCard _libraryCard;

        public CheckOutService(LibraryDbContext context, ILibraryAsset asset , ILibraryCard libraryCard)
        {
            _context = context;
            _asset = asset;
            _libraryCard = libraryCard;
        }

        public IEnumerable<CheckOutHistory> CheckOutHistory()
        {
            return _context.CheckOutHistories;
        }

        public CheckOut Get(int assetId)
        {
            return GetAll().FirstOrDefault(c => c.LibraryAsset.Id == assetId);
        }

        public IEnumerable<CheckOut> GetAll()
        {
            return _context.CheckOuts;
        }

        public void Add(CheckOut newCheckOut)
        {
            _context.Add(newCheckOut);
            _context.SaveChanges();
        }

        public void Remove(CheckOut checkOut)
        {
            _context.Remove(checkOut);
            _context.SaveChanges();
        }

        public void Update(CheckOut checkOut)
        {
            var update = Get(checkOut.Id);
            _context.Update(update);

            update = checkOut;

            _context.SaveChanges();
        }
        public void PlaceHold(int assetId, Guid cardId)
        {
            var asset = _asset.Get(assetId);
            var card = _libraryCard.GetCard(cardId);

            var hold = new Hold
            {
                Asset = asset,
                HoldPlaced = DateTime.UtcNow,
                Patron = new Patron { }
            };

            _context.Add(hold);
            _context.SaveChanges();
        }
        public void CheckInItem(int id)
        {
            // get the asset by id
            // start a context update
            // c
            var item = _asset.Get(id);

            _context.Update(item);

            var checkOut = Get(item.Id);

            if (checkOut != null)
            {
                DateTime now = DateTime.Now;
                CloseCheckOutHistories(checkOut.LibraryAsset ,now);
                Remove(checkOut);
            }
            item.Status = _asset.GetStatusByName("Available");

            _context.SaveChanges();
        }

        private DateTime AddDefaultReturnDays(DateTime now)
        {
            return now.AddDays(30);
        }

        private DateTime AddCostumDays(double days)
        {

            return DateTime.Now.AddDays(days);
        }

        private void CloseCheckOutHistories(LibraryAsset asset , DateTime now)
        {
            // get the hisotry of asset
            // start a context update 
            // update the CheckedIn time to now
            // save
            var checkIn = CheckOutHistory()
                .FirstOrDefault(c=>c.LibraryAsset.Id == asset.Id);

            _context.Update(checkIn);

            checkIn.CheckedIn = now;

            
            _context.SaveChanges(); 
        }

        public void CheckOutItem(int id)
        {
            // get the asset by id
            // update it 
            // Create/Add a new CheckOut
            // Create/Add a new CheckOutHistory
            // save 
            var item = _asset.Get(id);

            _context.Update(item);

            item.Status = _asset.GetStatusByName("Checked Out");

            DateTime now = DateTime.Now;

            var checkOut = new CheckOut
            {
                LibraryAsset = item,
                Card = item.LibraryCard,
                Until = AddDefaultReturnDays(now),
                Since = now,
                ReturnedOn = null,
            };

            Add(checkOut);

            var history = new CheckOutHistory
            {
                CheckedOut = checkOut.Since,
                LibraryAsset = item,
                CheckedIn = null,
                LibraryCard = checkOut.LibraryAsset.LibraryCard
            };
            
            _context.CheckOutHistories.Add(history);

            _context.SaveChanges();
        }

        public void MarkFound(int id)
        {
            var item = _asset.Get(id);
            var now = DateTime.Now;

            _context.Update(item);

            item.Status = _asset.GetStatusByName("Available");

            var checkOut = Get(item.Id);

            CloseCheckOutHistories(checkOut.LibraryAsset, now);
            Remove(checkOut);

            _context.SaveChanges();
        }
        
        public void MarkLost(int id)
        {      
            var asset = _asset.Get(id);

            _context.Update(asset);

            asset.Status = _asset.GetStatusByName("Lost");

            _context.SaveChanges();
        }
        
    }
}