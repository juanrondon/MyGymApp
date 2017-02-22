using MyGymApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.UI.Models.WorkoutPlanViewModels
{
    public class WorkoutPlanIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name ="Workout Sessions")]
        public string WorkoutSessions { get; set; }
    }
}
