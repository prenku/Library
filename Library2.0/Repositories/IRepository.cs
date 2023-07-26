using Library.Interfaces;
using Library.Repositories;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public interface IRepository
    {
        IHold HoldService { get; }
        ILibraryAsset LibraryAssetService { get; set; }
        ILibraryCard LibraryCardService { get; }
        IPatron PatronService { get; }
        IBranch BranchService { get; }
        ICheckOut CheckOutService { get; }
        IBook BookService { get; }
    }
}
