using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    public class EmtpyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}