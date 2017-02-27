using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyGymApp.DataAccess.Models
{
    public class WorkoutRecord
    {
        public int WorkoutRecordId { get; set; }
        [Required]
        public string ActivityName { get; set; }
        public int? DurationInMinutes { get; set; }
        public int? NumberOfSets { get; set; }
        public int? NumberOfReps { get; set; }
        public List<WorkoutRecordMuscle> MusclesTargeted{ get; set; }
        [Required]
        public int WorkoutSessionId { get; set; }
        public WorkoutSession WorkoutSession { get; set; }

        public WorkoutRecord()
        {
                MusclesTargeted = new List<WorkoutRecordMuscle>();
        }
    }
}
