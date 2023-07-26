using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public interface ILibraryCard
    {
        LibraryCard GetCard(Guid cardId);
    }
}
