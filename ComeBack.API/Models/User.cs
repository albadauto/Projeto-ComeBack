using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ComeBack.API.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }
    }
}
