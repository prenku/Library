using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    [Authorize]
    public class Patron : IdentityUser
    {
        public int PatronID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime MemeberSince { get; set; }
        public virtual Branch HomeBrach { get; set; }
        public string Address { get; set; }
        public IEnumerable<Dues> Dues { get; set; }
        public List<Hold> Holds { get; set; }
        public bool? Locked { get; set; }
        [Required]
        public  LibraryCard LibraryCard { get; set; }
        public  CheckOutHistory CheckOutHistory { get; set; }

        public Patron()
        {
            LibraryCard = new LibraryCard { Id = Guid.NewGuid() };
            Dues = new List<Dues>();
            Holds = new List<Hold>();
            Locked = false;   
        }
    }
}