using System.Collections.Generic;

namespace MyGymApp.Commands.WorkoutPlan
{
    public class CreateWorkoutPlanCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<DataAccess.Models.WorkoutSession> WorkoutSessions { get; set; }
    }
}
