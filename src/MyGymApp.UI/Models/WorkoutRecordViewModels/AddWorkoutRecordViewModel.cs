using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyGymApp.UI.Models.WorkoutRecordViewModels
{
    public class AddWorkoutRecordViewModel
    {
        [Required]
        [Display(Name = "Activity Name")]
        public string ActivityName { get; set; }
        public int Duration { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        [Required]
        public int[] MusclesListIds { get; set; }
        public MultiSelectList MusclesList { get; set; }
    }
}