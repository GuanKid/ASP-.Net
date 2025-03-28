using Microsoft.EntityFrameworkCore;
using RestuarantList.Models;

namespace RestuarantList.Data
{
    public class RestuarantListContext: DbContext
    {
     public RestuarantListContext(DbContextOptions<RestuarantListContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestuarantDish>().HasKey(rd => new
            {
                rd.RestuarantId,
                rd.DishId
            });

            modelBuilder.Entity<RestuarantDish>()
                .HasOne(r => r.Restuarant)
                .WithMany(rd=> rd.RestuarantDishes)
                .HasForeignKey(r => r.RestuarantId);

            modelBuilder.Entity<RestuarantDish>()
                .HasOne(d => d.Dish)
                .WithMany(rd => rd.RestuarantDishes)
                .HasForeignKey(r => r.DishId);

            modelBuilder.Entity<Restuarant>().HasData(
                new Restuarant
                {
                    Id = 1,
                    Name = "Gourmet Pizzeria",
                    Address =  "10 Echola St, Motherwell, EC, 6211",
                    ImageURL = "https:www.whereyoueat.com/r_gallery_images/rgallery-21635/Best_Italian_Pizza2.jpg"
                });

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Pizza", price = 10 },
                new Dish { Id = 2, Name = "Pasta", price = 9 });

            modelBuilder.Entity<RestuarantDish>().HasData(
                new RestuarantDish { RestuarantId = 1, DishId = 1 },
                new RestuarantDish { RestuarantId = 1, DishId = 2 });

            base.OnModelCreating(modelBuilder);
                
        }

        public DbSet<Restuarant> Restuarants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<RestuarantDish> RestuarantDishes { get; set; }
    }
}
