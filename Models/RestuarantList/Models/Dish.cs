namespace RestuarantList.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double price { get; set; }

        public List<RestuarantDish>? RestuarantDishes { get; set; }
    }
}
