using Mezo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mezo.Data
{
    public class MezoDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DeliveryArea> DeliveryAreas{ get; set; }
        public DbSet<Courier> Couriers { get; set; }
        
        public string DbPath { get; }

        //Wouldn't normally do this but, for demo purposes...
        public MezoDbContext()
        {
            DbPath = Path.Join(Environment.CurrentDirectory, "MezoShopping.db");
        }

        //Configuring EF to use a SQlite database
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Again, you wouldn't normally do this but, for demo purposes...
            //Seed Couriers
            modelBuilder.Entity<Courier>().HasData(new Courier()
            {
                Id = 1,
                Cost = 3.99M,
                Name = "Royal Mail",
                IsDefaultCourier = true
            });

            modelBuilder.Entity<Courier>().HasData(new Courier()
            {
                Id = 2,
                Cost = 5.99M,
                Name = "Panda Parcels",
                IsDefaultCourier = false
            });

            //Seed Undeliverable Areas
            modelBuilder.Entity<DeliveryArea>().HasData(new DeliveryArea()
            {
                Id = 1,
                AreaName = "Cornwall",
                CanDeliver = false
            });

            modelBuilder.Entity<DeliveryArea>().HasData(new DeliveryArea()
            {
                Id = 2,
                AreaName = "Exeter",
                CanDeliver = false
            });

            modelBuilder.Entity<DeliveryArea>().HasData(new DeliveryArea()
            {
                Id = 3,
                AreaName = "Watford",
                CanDeliver = false
            });

            modelBuilder.Entity<DeliveryArea>().HasData(new DeliveryArea()
            {
                Id = 4,
                AreaName = "Scotland",
                CanDeliver = false
            });

            //Seed deliverable areas by Panda Parcels
            modelBuilder.Entity<DeliveryArea>().HasData(new DeliveryArea()
            {
                Id = 5,
                AreaName = "Croydon",
                CanDeliver = true,
                CourierId = 2
            });

            modelBuilder.Entity<DeliveryArea>().HasData(new DeliveryArea()
            {
                Id = 6,
                AreaName = "Thorton Heath",
                CanDeliver = true,
                CourierId = 2
            });

            modelBuilder.Entity<DeliveryArea>().HasData(new DeliveryArea()
            {
                Id = 7,
                AreaName = "Dartford",
                CanDeliver = true,
                CourierId = 2
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
