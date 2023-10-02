using Carter;
using Mezo.Core.Shared.Dtos;
using Mezo.Core.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mezo.Api.Endpoints.Courier
{
    public class CourierEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetCourierServiceByAddressId/{id}", GetCourierServiceByAddressId);
        }

        private async Task<CourierDto> GetCourierServiceByAddressId(long id, [FromServices]ICourierService courierService)
        {
            return await courierService.GetCourierByAddressId(id);
        }
    }
}
