using Mezo.Core.Services;
using Mezo.Data.Entities;
using Mezo.Data.Repositories.Interfaces;
using NSubstitute;
using Shouldly;

namespace Mezo.Tests
{
    public class UserStory1 : TestBase
    {
        private readonly IRepository<DeliveryArea> _deliveryAreaRepositoryMock;

        public UserStory1()
        {
            _deliveryAreaRepositoryMock = Substitute.For<IRepository<DeliveryArea>>();
            _deliveryAreaRepositoryMock.GetAllAsync().Returns(DeliveryAreaSetup);
        }

        [Fact]
        public async Task Given_Address_ShouldBeDeliverable()
        {
            //Arrange
            var addressRepositoryMock = Substitute.For<IRepository<Address>>();
            addressRepositoryMock.GetByIdAsync(1).Returns(new Address()
            {
                Id = 1,
                AddressLine1 = "1 Citadel Promenade",
                AddressLine2 = "",
                AddressLine3 = "",
                County = "Kent",
                PostalCode = "ME1 1RP"
            });

            var addressService = new AddressService(addressRepositoryMock);

            var sut = new PostalCheckService(addressService, _deliveryAreaRepositoryMock);

            // Act
            var result = await sut.EnsureCanDeliverToAddress(1);

            //Assert
            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData("Cornwall", "England")]
        [InlineData("Exeter", "England")]
        [InlineData("Watford", "England")]
        [InlineData("Aberdeen", "Scotland")]
        public async Task Given_Address_AreaShouldNotBeDeliverable(string county, string country)
        {
            //Arrange
            var addressRepositoryMock = Substitute.For<IRepository<Address>>();
            addressRepositoryMock.GetByIdAsync(1).Returns(new Address()
            {
                Id = 1,
                AddressLine1 = "1 Citadel Promenade",
                AddressLine2 = "",
                AddressLine3 = "",
                County = county,
                Country = country,
                PostalCode = "ME1 1RP"
            });

            var addressService = new AddressService(addressRepositoryMock);

            var sut = new PostalCheckService(addressService, _deliveryAreaRepositoryMock);

            // Act
            var result = await sut.EnsureCanDeliverToAddress(1);

            //Assert
            result.ShouldBeFalse();
        }

        
    }
}