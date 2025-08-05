
using Ordering.Application.Orders.Queries.GetOrderByCustomer;

namespace Ordering.API.Endpoints;

//- Accepts a customer ID as a parameter.
//- Uses a GetOrdersByCustomerQuery to fetch orders.
//- Retrurns the list of order for that customer.

//public record GetOrdersByCustomer(Guid CustomerId);
public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{CustomerId}", async (Guid CustomerId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByCustomerQuery(CustomerId));

            var response = result.Adapt<GetOrdersByCustomerResponse>();

            return Results.Ok(response);
        })
          .WithName("GetOrdersByCustomer")
          .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .ProducesProblem(StatusCodes.Status404NotFound)
          .WithSummary("GetOrders By Customer")
          .WithDescription("GetOrders By Customer");
    }
}
