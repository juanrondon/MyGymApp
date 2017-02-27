using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.DataAccess.Models
{
    public class WorkoutRecordMuscle
    {
        public int WorkoutRecordId { get; set; }
        public WorkoutRecord WorkoutRecord { get; set; }
        public int MuscleId { get; set; }
        public Muscle Muscle { get; set; }
    }
}
