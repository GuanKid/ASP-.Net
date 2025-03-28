namespace RestuarantList.Models
{
    public class RestuarantDish
    {
        public int RestuarantId { get; set; }

        public Restuarant Restuarant { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }
    }
}
