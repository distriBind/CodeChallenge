using Carter;
using Mezo.Core.Shared.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mezo.Api.Endpoints.Delivery
{
    public class DeliveryAreaEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetDeliveryCheck/{id}", CheckDelivery);
        }

        private async Task<Results<Ok<bool>, NotFound<string>>> CheckDelivery(long id, [FromServices]IPostalCheckService postalCheckService)
        {
            var result = await postalCheckService.EnsureCanDeliverToAddress(id);

            if (!result)
                return TypedResults.NotFound("No postal service available to cover the area");

            return TypedResults.Ok(result);
        }
    }
}
