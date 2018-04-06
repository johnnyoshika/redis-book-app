using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RedisBookApp
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() =>
            Content("Hello world!");
    }
}
