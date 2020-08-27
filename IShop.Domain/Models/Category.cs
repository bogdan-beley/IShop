
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace IShop.Domain.Models
{
    public class Category : IIdentifiable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is requared.")]
        public string Name { get; set; }
    }
}
