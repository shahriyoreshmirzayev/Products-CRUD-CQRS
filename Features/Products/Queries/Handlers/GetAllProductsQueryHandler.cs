using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Entities;

namespace Products.Features.Products.Queries.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly ApplicationDbContext _context;

    public GetAllProductsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .OrderBy(p => p.Name)
            //.
            .ToListAsync(cancellationToken);
    }
}
