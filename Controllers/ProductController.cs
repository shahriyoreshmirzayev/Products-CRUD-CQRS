using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Features.Products.Commands;
using Products.Features.Products.Queries;
using Products.Models;

namespace Products.Controllers;


[Authorize]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: Product
    public async Task<IActionResult> Index()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return View(products);
    }

    // GET: Product/Details/5
    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0)
            return BadRequest();

        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();

        return View(product);
    }

    // GET: Product/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return View(productDto);
        }

        try
        {
            var command = new CreateProductCommand
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock
            };

            var productId = await _mediator.Send(command);
            TempData["SuccessMessage"] = "Mahsulot muvaffaqiyatli qo'shildi";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Xatolik yuz berdi: " + ex.Message);
            return View(productDto);
        }
    }

    // GET: Product/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (id <= 0)
            return BadRequest();

        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();

        var productDto = new UpdateProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock
        };

        return View(productDto);
    }

    // POST: Product/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateProductDto productDto)
    {
        if (id != productDto.Id)
            return BadRequest();

        if (!ModelState.IsValid)
        {
            return View(productDto);
        }

        try
        {
            var command = new UpdateProductCommand
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock
            };

            var result = await _mediator.Send(command);
            if (!result)
            {
                TempData["ErrorMessage"] = "Mahsulot topilmadi";
                return NotFound();
            }

            TempData["SuccessMessage"] = "Mahsulot muvaffaqiyatli yangilandi";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Xatolik yuz berdi: " + ex.Message);
            return View(productDto);
        }
    }

    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();

        return View(product);
    }

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            if (!result)
            {
                TempData["ErrorMessage"] = "Mahsulot topilmadi";
                return NotFound();
            }

            TempData["SuccessMessage"] = "Mahsulot muvaffaqiyatli o'chirildi";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Xatolik yuz berdi: " + ex.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
