using System.ComponentModel.DataAnnotations;

namespace ComeBack.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
    }
}
