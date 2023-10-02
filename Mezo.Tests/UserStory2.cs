using Mezo.Core.Services;
using Mezo.Core.Shared.Dtos;
using Mezo.Core.Shared.Services;
using Mezo.Data.Entities;
using Mezo.Data.Repositories.Interfaces;
using NSubstitute;
using Shouldly;

namespace Mezo.Tests
{
    public class UserStory2 : TestBase
    {
        [Theory]
        [ClassData(typeof(UserStory2Data))]
        public async Task Given_AddressIsDeliverable_SelectCorrectCourier(string county, bool isDefaultCourier, string expectedCourierName)
        {
            //Arrange
            var deliveryAreaRepositoryMock = Substitute.For<IRepository<DeliveryArea>>();
            var courierRepositoryMock = Substitute.For<IRepository<Courier>>();
            var postalCheckServiceMock = Substitute.For<IPostalCheckService>();
            var addressServiceMock = Substitute.For<IAddressService>();
            var expectedType = typeof(CourierDto);

            deliveryAreaRepositoryMock.GetAllAsync().ReturnsForAnyArgs(DeliveryAreaSetup);

            addressServiceMock.GetById(1).Returns(new AddressDto()
            {
                Id = 1,
                AddressLine1 = "1 Citadel Promenade",
                AddressLine2 = "",
                AddressLine3 = "",
                County = county,
                PostalCode = "ME1 1RP"
            });

            postalCheckServiceMock.EnsureCanDeliverToAddress(1).Returns(true);

            courierRepositoryMock.GetAllAsync().Returns(AvailableCouriersSetup);

            var sut = new CourierService(
                deliveryAreaRepositoryMock,
                postalCheckServiceMock,
                addressServiceMock,
                courierRepositoryMock
            );

            //Act
            var result = await sut.GetCourierByAddressId(1);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType(expectedType);
            result.IsDefaultCourier.ShouldBe(isDefaultCourier);
            result.Name.ShouldBe(expectedCourierName);
        }
    }
}
