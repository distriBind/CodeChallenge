using Mezo.Core.Mappers;
using Mezo.Core.Shared.Dtos;
using Mezo.Data.Entities;
using Mezo.Data.Repositories.Interfaces;
using Mezo.Data.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Mezo.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private CustomerMapper _customerMapper;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _customerMapper = new CustomerMapper();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id, customer => customer
                .Include(c => c.Address)
                .Include(c => c.Orders));

            if (customer == null)
                return null;

            //Probably should use a mapper here
            return new CustomerDto()
            {
                Id = customer.Id,
                Address = new AddressDto()
                {
                    Id = customer.Address.Id,
                    AddressLine1 = customer.Address.AddressLine1,
                    AddressLine2 = customer.Address.AddressLine2,
                    AddressLine3 = customer.Address.AddressLine3,
                    County = customer.Address.County,
                    PostalCode = customer.Address.PostalCode,
                },
                Email = customer.Email,
                Firstname = customer.Firstname,
                Surname = customer.Surname,
                Orders = customer.Orders.Select(o => new OrderDto()
                {
                    Id = o.Id,
                    Description = o.Description,
                })
            };
        }

        public async Task<bool> CreateCustomerAsync(CustomerDto customer)
        {
            var entriesMade = await _customerRepository.CreateAsync(new Customer()
            {
                Firstname = customer.Firstname,
                Surname = customer.Surname,
                Email = customer.Email,
                Address = new Address()
                {
                    AddressLine1 = customer.Address.AddressLine1,
                    AddressLine2 = customer.Address.AddressLine2,
                    AddressLine3 = customer.Address.AddressLine3,
                    County = customer.Address.County,
                    Country = customer.Address.Country,
                    PostalCode = customer.Address.PostalCode,
                },
                Orders = new List<Order>()
            });

            return entriesMade > 0;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync(customer => customer.Address);

            return customers.Select(_customerMapper.CustomerToCustomerDto);
        }
    }
}
