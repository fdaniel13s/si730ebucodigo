using Microsoft.AspNetCore.Mvc;
using si730ebucodigo.API.Inventory.Domain.Model.Queries;
using si730ebucodigo.API.Inventory.Domain.Services;
using si730ebucodigo.API.Inventory.Interfaces.REST.Resources;
using si730ebucodigo.API.Inventory.Interfaces.REST.Transform;

namespace si730ebucodigo.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService
    ):ControllerBase
{
    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var product =  await productQueryService.Handle(new GetProductByIdQuery(productId));
        if (product == null)
        {
            return NotFound();
        }
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product == null)
        {
            return BadRequest(new { message = "Review your parameters. RULES: Brand and Model are required, SerialNumber is unique, StatusDescription is required" });
        }
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, productResource);
    }
}