using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AllNotesFront.Models;
using AllNotesFront.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AllNotesFront.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private UserServices _userServices;

        public UserController(ILogger<UserController> logger, UserServices userServices)
        {
            this._logger = logger;
            this._userServices = userServices;

        }

        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _userServices.Login(model);
                if (result.Equals("Success"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = result;
                    return View();
                }
            }
            
            return View() ;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}