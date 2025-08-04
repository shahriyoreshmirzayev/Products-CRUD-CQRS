using MediatR;
using Products.Entities;

namespace Products.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<Product?>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
