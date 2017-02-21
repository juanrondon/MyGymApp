using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.DataAccess.Models
{
    public class WorkoutPlan
    {
        public int WorkoutPlanId { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }
        public List<WorkoutSession> WorkoutSessions { get; set; }

        public WorkoutPlan()
        {
            WorkoutSessions = new List<WorkoutSession>();
        }
    }
}
