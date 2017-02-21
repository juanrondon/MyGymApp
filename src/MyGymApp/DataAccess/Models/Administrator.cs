using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
