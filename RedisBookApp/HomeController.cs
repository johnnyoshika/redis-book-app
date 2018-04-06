using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RedisBookApp
{
    public class HomeController : Controller
    {
        public HomeController(IRepository repository)
        {
            Repository = repository;
        }

        IRepository Repository { get; }

        public async Task<IActionResult> Index() =>
            View("~/Index.cshtml", await Repository.GetBooksAsync());
    }
}
