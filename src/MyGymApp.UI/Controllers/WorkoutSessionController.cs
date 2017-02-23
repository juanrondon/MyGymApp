using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyGymApp.DataAccess.Models;
using MyGymApp.Services;
using MyGymApp.UI.Models.WorkoutSessionViewModels;
using MyGymApp.Commands.WorkoutSession;

namespace MyGymApp.UI.Controllers
{
    public class WorkoutSessionController : Controller
    {
        private readonly MyGymAppDbContext _context;
        private readonly WorkoutSessionApplicationService _workoutSessionService;

        public WorkoutSessionController(MyGymAppDbContext context, WorkoutSessionApplicationService workoutSessionService)
        {
            _context = context;
            _workoutSessionService = workoutSessionService;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetMuscles()
        {
            var result = _context.Muscles.ToList();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("MyWorkoutSessions/Create")]
        public async Task<IActionResult> Create(WorkoutSessionCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var command = new CreateWorkoutSessionCommand
            {
                Description = model.Description,
                Date = model.Date
                //TODO: Complete logic
            };
            await _workoutSessionService.AddWorkoutSession(command);
            return RedirectToAction("Index");
        }
    }
}