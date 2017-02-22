using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.Commands.WorkoutSession
{
    public class CreateWorkoutSessionCommand
    {
        public string Description { get; set; }        
        public DateTime Date { get; set; }
        public int WorkoutPlanId { get; set; }
        public int UserId { get; set; }
    }
}
