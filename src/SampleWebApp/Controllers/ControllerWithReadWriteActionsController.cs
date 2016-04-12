using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace SampleWebApp.Controllers
{
    public class ControllerWithReadWriteActionsController : Controller
    {
        // GET: ControllerWithReadWriteActions
        public ActionResult Index()
        {
            return View();
        }

        // GET: ControllerWithReadWriteActions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControllerWithReadWriteActions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControllerWithReadWriteActions/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ControllerWithReadWriteActions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ControllerWithReadWriteActions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ControllerWithReadWriteActions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControllerWithReadWriteActions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
