using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Web.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
