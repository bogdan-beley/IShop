
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace IShop.Domain.Models
{
    public class Product : IIdentifiable
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} is requared.")]
        public int CategoryId { get; set; }
        
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1} symbols.", MinimumLength = 3)]
        [Required(ErrorMessage = "{0} is requared.")]
        public string Name { get; set; }
        
        [Range(0, 100000, ErrorMessage = "{0} must be in the range from {2} to {1}.")]
        [Required(ErrorMessage = "Price is requared.")]
        public double Price { get; set; }
    }
}
