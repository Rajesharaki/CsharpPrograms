using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepo repo;

        public HomeController(IUserRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Creating(User user)
        {
            if(ModelState.IsValid)
            {
                repo.Add(user);
            }
            return View();
        }
        public IActionResult Delete(int id)
        { 
            if(this.repo!=null)
            {
                this.repo.Delete(id);
            }
            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            var user = this.repo.GetUser(id);
            return View(user);
        }
        public IActionResult Edit(int id)
        {
            var user = this.repo.GetUser(id);
            return View(user);
        }
        public IActionResult Update(User user)
        {
            repo.Update(user);
            return RedirectToAction("List");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult List()
        {
            var list = repo.GetUsers();
            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
