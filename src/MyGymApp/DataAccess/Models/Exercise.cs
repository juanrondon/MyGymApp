using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApp.DataAccess.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string TargetedMuscles { get; set; }
    }
}
