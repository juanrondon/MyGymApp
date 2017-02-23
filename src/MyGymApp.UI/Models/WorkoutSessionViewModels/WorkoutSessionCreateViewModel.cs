using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyGymApp.DataAccess.Models;
using MyGymApp.UI.Models.WorkoutRecordViewModels;

namespace MyGymApp.UI.Models.WorkoutSessionViewModels
{
    public class WorkoutSessionCreateViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public List<AddWorkoutRecordViewModel> WorkoutRecords { get; set; }
    }
}
