using System.ComponentModel.DataAnnotations;

namespace MyGymApp.DataAccess.Models
{
    public class Muscle
    {
        public int MuscleId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
