using System.ComponentModel.DataAnnotations;

namespace MyGymApp.DataAccess.Models
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
