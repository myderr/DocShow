﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocShow.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("/Error/500")]
        public IActionResult Error500()
        {
            return View();
        }
    }
}
