using Mezo.Core.Shared.Dtos;

namespace Mezo.Data.Shared.Services
{
    public interface ICustomerService : IDomainService
    {
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<bool> CreateCustomerAsync(CustomerDto customer);
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
    }
}
