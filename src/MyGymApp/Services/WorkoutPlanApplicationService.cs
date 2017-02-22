using MyGymApp.Commands.WorkoutPlan;
using MyGymApp.DataAccess.Models;
using System.Threading.Tasks;

namespace MyGymApp.Services
{
    public class WorkoutPlanApplicationService
    {
        private readonly MyGymAppDbContext _context;

        public WorkoutPlanApplicationService(MyGymAppDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutPlan> Create(CreateWorkoutPlanCommand command)
        {
            var workoutPlan = new WorkoutPlan
            {
                Name = command.Name,
                Description = command.Description,
                UserId = 1, //TODO: Fix user id
                WorkoutSessions = command.WorkoutSessions
            };
            _context.WorkoutPlans.Add(workoutPlan);
            await _context.SaveChangesAsync();
            return workoutPlan;
        }
    }
}
