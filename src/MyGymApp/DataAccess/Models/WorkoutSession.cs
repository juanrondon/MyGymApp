using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.DataAccess.Models
{
    public class WorkoutSession
    {
        public int WorkoutSessionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public int? WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }

        public List<WorkoutRecord> WorkoutRecords { get; set; }

        public WorkoutSession()
        {
            WorkoutRecords = new List<WorkoutRecord>();
        }
    }
}
