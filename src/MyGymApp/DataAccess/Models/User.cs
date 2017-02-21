using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGymApp.DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(13)")]
        public string mobileNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Email { get; set; }
        public Address Address { get; set; }        

        // User Avatar
        public byte[] Avatar { get; set; }
        [Required]
        public int AvatarId { get; set; }
    }
}
