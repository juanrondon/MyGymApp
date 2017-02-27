using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGymApp.DataAccess.Models;

namespace MyGymApp.Commands.WorkoutSession
{
    public class CreateWorkoutSessionCommand
    {
        public string Description { get; set; }        
        public DateTime Date { get; set; }
        public List<WorkoutRecord> WorkoutRecords { get; set; }
        public int UserId { get; set; }
    }
}
