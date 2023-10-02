using Carter;
using Mezo.Core.Shared.Dtos;
using Mezo.Data.Shared.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Mezo.Api.Endpoints.Customer
{
    public class CustomerEndpointsModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/CreateCustomer", CreateCustomer);
            app.MapGet("/GetCustomers", GetAllCustomers);
        }

        private async Task<Results<Ok<IEnumerable<CustomerDto>>, NotFound>> GetAllCustomers(ICustomerService service)
        {
            var customers = await service.GetAllCustomers();

            return !customers.Any() ? TypedResults.NotFound() : TypedResults.Ok(customers);
        }

        internal async Task CreateCustomer(ICustomerService service, CustomerDto customer)
        {
            var isSuccess = await service.CreateCustomerAsync(customer);
        }


    }
}
