using Library.Interfaces;
using Library.Models;
using Library.ViewModels.Patrons;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class PatronsController : Controller
    {
        private IPatron _patron;
        private UserManager<Patron> _userManager;
        private readonly IEmailService _emailService;
        public PatronsController(IPatron patron , UserManager<Patron> userManager)
        {
            _patron = patron;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = new PatronsIndexViewModel
            {
                Patrons = _patron.GetAll()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePatronViewModel {  });    
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatronViewModel model)
        {

            var uniqueEmail = await _userManager.FindByEmailAsync(model.Email);

            if (uniqueEmail is null)
            {
                var patron = new Patron
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    Address = model.Address,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    EmailConfirmed = false,
                    UserName = model.UserName,
                    HomeBrach = _patron.Get(1).HomeBrach
                };

                var result = await _userManager.CreateAsync(patron);
                if (result.Succeeded)
                {
                    //To do Send an Email
                    // with instructions to set up the account
                    var emailLink = await _userManager.GeneratePasswordResetTokenAsync(patron);

                    await  _emailService.SendAsync(model.Email,$"Set up Your Account for {patron.HomeBrach.Name}","");

                }
            }
            return View(); 

           // if you come this far ALERT USER eg:send email to model.Email 
           // letting them know someone tri
        }
    }
}
