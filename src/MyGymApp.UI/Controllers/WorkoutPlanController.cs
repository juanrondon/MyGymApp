using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyGymApp.DataAccess.Models;
using MyGymApp.Services;
using MyGymApp.UI.Models.WorkoutPlanViewModels;

namespace MyGymApp.UI.Controllers
{
    public class WorkoutPlanController : Controller
    {
        private readonly MyGymAppDbContext _context;
        private WorkoutPlanApplicationService _workoutPlanService;

        public WorkoutPlanController(MyGymAppDbContext context, WorkoutPlanApplicationService workoutPlanService)
        {
            _context = context;
            _workoutPlanService = workoutPlanService;
        }


        public IActionResult Index()
        {
            var workoutPlans = _context.WorkoutPlans.Select(wp => new WorkoutPlanIndexViewModel
            {
                Id = wp.WorkoutPlanId,
                Name = wp.Name,
                Description = wp.Description,
                WorkoutSessions = (wp.WorkoutSessions.Count > 0) ? wp.WorkoutSessions.Count + " Sessions" : "No Sessions"
            }).ToList();
            return View(workoutPlans);
        }
    }
}