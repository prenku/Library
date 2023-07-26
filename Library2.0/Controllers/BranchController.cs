using Library.Interfaces;
using Library.Models;
using Library.ViewModels.Branch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BranchesController : Controller
    {
        private IBranch _branch;

        public BranchesController(IBranch branch)
        {
            _branch = branch;
        }
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Branchs = _branch.GetAll()
            };
            return View(model);
        }
        public IActionResult Create()
        {
            return View(new CreateBranchViewModel { });
        }
        [HttpPost]
        public IActionResult Create(CreateBranchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Snap..", "Please fill in all the filds");
                return View();
            }
               

            var branch = new Library.Models.Branch
            {
                Estabilished = model.Estabilished,
                Name = model.Name,
                Location = model.Location,
                Description = model.Description,
                Telephone = model.Telephone,
                Image = model.Image,
                Patrons = new List<Patron>()
            };

            _branch.Add(branch);

            return Redirect("Index");
        }
        public IActionResult Delete(int id)
        {
           
            _branch.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
           var branch = _branch.Get(id);
            return View(branch);
        }
       
    }
}
