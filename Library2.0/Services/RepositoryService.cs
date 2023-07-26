using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;
using Library.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Services
{
    public class RepositoryService : IRepository
    {
        private IServiceProvider _serviceProvider;

        public RepositoryService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILibraryAsset LibraryAssetService { get => _serviceProvider.GetRequiredService<ILibraryAsset>(); set => throw new NotImplementedException(); }

        public ILibraryCard LibraryCardService => _serviceProvider.GetRequiredService<ILibraryCard>();

        public IHold HoldService => _serviceProvider.GetRequiredService<IHold>();

        public IPatron PatronService => _serviceProvider.GetRequiredService<IPatron>();

        public IBranch BranchService => _serviceProvider.GetRequiredService<IBranch>();

        public ICheckOut CheckOutService => _serviceProvider.GetRequiredService<ICheckOut>();

        public IBook BookService => _serviceProvider.GetRequiredService<IBook>();
    }
}