namespace FoodDelivery.Web.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public double Discount { get; set; }
        public double MinimumAmount { get; set; }
        public byte[] CouponPicture { get; set; }
        public bool IsActive { get; set; }
    }

    public enum CoupnType
    {
        Percent = 0,
        Currency = 1
    }
}

