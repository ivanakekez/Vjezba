using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vjezba.Models;
using Vjezba.Models.Dbo;
using Vjezba.Services.Interfaces;

namespace Vjezba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService accountService;

        public HomeController( IAccountService accountService)
        {
          
            this.accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task <IActionResult> Profile()

        {
            var profile=await accountService.GetUserProfile(User);

            return View(profile);
        }


        [Authorize]
        public IActionResult CreateTodoList()

        {
            
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult CreateTodoList(TodoList model)
        {

            accountService.AddToDoList(model, User);
            return RedirectToAction("Profile");
        }


        [Authorize]

        public async Task<IActionResult> MyTodoList()
        { 
        var myTodoList=await accountService.GetTodoList(User);
            return View(myTodoList);
        
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
