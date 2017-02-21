using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.DataAccess.Models
{
    public class WorkoutRecord
    {
        public int WorkoutRecordId { get; set; }
        public int? DurationInMinutes { get; set; }
        public int? NumberOfSets { get; set; }
        public int? NumberOfReps { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        [Required]
        public int WorkoutSessionId { get; set; }
        public WorkoutSession WorkoutSession { get; set; }
    }
}
