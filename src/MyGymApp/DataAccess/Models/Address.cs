using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MyGymApp.DataAccess.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        [Column(TypeName = "varchar(7)")]
        public string StreetNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string StreetName { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Suburb { get; set; }
        [Required]
        public int Postcode { get; set; }
    }
}