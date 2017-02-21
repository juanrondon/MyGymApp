using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.UI.Models.WorkoutSessionViewModels
{
    public class WorkoutSessionCreateViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int workoutPlanId { get; set; }
    }
}
