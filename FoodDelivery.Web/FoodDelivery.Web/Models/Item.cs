namespace FoodDelivery.Web.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }



        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public double Price { get; set; }


        public int SubCategoryId { get; set; }
        public SubCategory  SubCategory { get; set; }
    }
}
