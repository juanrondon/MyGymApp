using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyGymApp.DataAccess.Models;
using MyGymApp.Services;
using MyGymApp.UI.Models.WorkoutSessionViewModels;

namespace MyGymApp.UI.Controllers
{
    public class WorkoutSessionController : Controller
    {
        private MyGymAppDbContext _context;
        private WorkoutSessionApplicationService _WorkoutSessionService;

        public WorkoutSessionController(MyGymAppDbContext context, WorkoutSessionApplicationService workoutSessionService)
        {
            _context = context;
            _WorkoutSessionService = workoutSessionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var results = _context.WorkoutSessions.Select(ws => new WorkoutSessionIndexViewModel
            {
                Id = ws.WorkoutSessionId,
                Description = ws.Description,
                Date = ws.Date,
                WorkoutRecords = ws.WorkoutRecords.Count                
            }).ToList();
            return View(results);
        }

        [HttpGet]
        [Route("MyWorkoutSessions/Create")]
        public IActionResult Create(int? workoutPlanId)
        {
            var model = new WorkoutSessionCreateViewModel();
            if (workoutPlanId != null)
            {
                model.workoutPlanId = workoutPlanId.Value;
            }
            return View(model);
        }
    }
}