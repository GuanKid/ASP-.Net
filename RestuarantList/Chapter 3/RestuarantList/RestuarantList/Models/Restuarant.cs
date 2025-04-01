namespace RestuarantList.Models
{
    public class Restuarant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string Address { get; set; }

        public List<RestuarantDish>? restuarantDishes { get; set; }
    }
}
