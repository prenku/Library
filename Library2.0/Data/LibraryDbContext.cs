using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : IdentityDbContext<IdentityUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Patron> Patrons { get; set; }
        public DbSet<LibraryAsset> LibraryAssets { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CheckOutHistory> CheckOutHistories { get; set; }
    }
}
