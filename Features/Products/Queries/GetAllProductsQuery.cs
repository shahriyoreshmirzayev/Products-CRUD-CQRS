using MediatR;
using Products.Entities;

namespace Products.Features.Products.Queries;

public class GetAllProductsQuery : IRequest<List<Product>>
{
}
