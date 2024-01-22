using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Web.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Item { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        [Required, MinLength(1)]
        public int Count { get; set; }
    }
}
