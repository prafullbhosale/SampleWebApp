using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    public class ControllerWithReadWriteActionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}