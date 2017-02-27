using System.Threading.Tasks;
using MyGymApp.Commands.WorkoutSession;
using MyGymApp.DataAccess.Models;

namespace MyGymApp.Services
{
    public class WorkoutSessionApplicationService
    {
        private readonly MyGymAppDbContext _context;

        public WorkoutSessionApplicationService(MyGymAppDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutSession> AddWorkoutSession(CreateWorkoutSessionCommand command)
        {
            var workoutSession = new WorkoutSession
            {
                Description = command.Description,
                Date = command.Date,
                WorkoutRecords = command.WorkoutRecords,
                UserId = 1 // TODO : Change to proper userId
            };
            _context.WorkoutSessions.Add(workoutSession);
            await _context.SaveChangesAsync();
            return workoutSession;
        }
    }
}