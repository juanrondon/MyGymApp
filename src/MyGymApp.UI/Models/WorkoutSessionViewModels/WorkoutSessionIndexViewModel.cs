using System;
using System.ComponentModel.DataAnnotations;

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
