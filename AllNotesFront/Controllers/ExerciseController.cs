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
    public class ExerciseController : Controller
    {
        private readonly ILogger<ExerciseController> _logger;
        private ExerciseServices _exerciseServices;

        public ExerciseController(ILogger<ExerciseController> logger, ExerciseServices exerciseServices)
        {
            this._logger = logger;
            this._exerciseServices = exerciseServices;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _exerciseServices.GetAllAsync();
            ViewBag.Data = result;

            return View();
        }
    }
}