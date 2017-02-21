using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGymApp.UI.Models.WorkoutSessionViewModels
{
    public class WorkoutSessionIndexViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }       
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
        [Display(Name = "Workout Records")]
        public int WorkoutRecords { get; set; }
    }
}
