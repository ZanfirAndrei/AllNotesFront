using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotesFront.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AllNotesFront.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ILogger<ScheduleController> _logger;
        private ScheduleServices _scheduleservices;

        public ScheduleController(ILogger<ScheduleController> logger, ScheduleServices scheduleservices)
        {
            this._logger = logger;
            this._scheduleservices = scheduleservices;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _scheduleservices.GetAllAsync();
            ViewBag.Data = result;

            return View();
        }

        public async Task<ViewResult> Add()
        {
            //string schedule = "2020-02-08 00:00:00.000";
            //var result = await _scheduleservices.CreateAsync(schedule);
            //ViewBag.Data = result;

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string date)
        {
            //string schedule = "2020-02-08 00:00:00.000";
            var result = await _scheduleservices.CreateAsync(date);

            return View("Index");
        }


        //// GET: Schedule
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Schedule/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Schedule/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Schedule/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Schedule/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Schedule/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Schedule/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Schedule/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}