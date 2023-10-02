using Mezo.Data.Entities;

namespace Mezo.Tests
{
    public class TestBase
    {
        public IEnumerable<DeliveryArea> DeliveryAreaSetup =>
            new List<DeliveryArea>()
            {
                //Seed Undeliverable Areas
                new()
                {
                    Id = 1,
                    AreaName = "Cornwall",
                    CanDeliver = false
                },
                new()
                {
                    Id = 2,
                    AreaName = "Exeter",
                    CanDeliver = false
                },
                new()
                {
                    Id = 3,
                    AreaName = "Watford",
                    CanDeliver = false
                },
                new()
                {
                    Id = 4,
                    AreaName = "Scotland",
                    CanDeliver = false
                },

                //Seed deliverable areas by Panda Parcels
                new()
                {
                    Id = 5,
                    AreaName = "Croydon",
                    CanDeliver = true,
                    CourierId = 2,
                    Courier =  new()
                    {
                        Id = 2,
                        Cost = 5.99M,
                        Name = "Panda Parcels",
                        IsDefaultCourier = false
                    }
                },

                new()
                {
                    Id = 6,
                    AreaName = "Thorton Heath",
                    CanDeliver = true,
                    CourierId = 2,
                    Courier =  new()
                    {
                        Id = 2,
                        Cost = 5.99M,
                        Name = "Panda Parcels",
                        IsDefaultCourier = false
                    }
                },

                new()
                {
                    Id = 7,
                    AreaName = "Dartford",
                    CanDeliver = true,
                    CourierId = 2,
                    Courier =  new()
                    {
                        Id = 2,
                        Cost = 5.99M,
                        Name = "Panda Parcels",
                        IsDefaultCourier = false
                    }
                }
            };

        public IEnumerable<Courier> AvailableCouriersSetup =>
            new List<Courier>()
            {
                new()
                {
                    Id = 1,
                    Cost = 3.99M,
                    Name = "Royal Mail",
                    IsDefaultCourier = true
                },
                new()
                {
                    Id = 2,
                    Cost = 5.99M,
                    Name = "Panda Parcels",
                    IsDefaultCourier = false
                }
            };
    }
}
