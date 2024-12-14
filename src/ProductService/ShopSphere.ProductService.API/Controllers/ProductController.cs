using Microsoft.AspNetCore.Mvc;
using ShopSphere.ProductService.Application.Interfaces;
using ShopSphere.ProductService.Domain.Entities;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
  private readonly IProductService _productService;

  public ProductController(IProductService productService)
  {
    _productService = productService;
  }

  [HttpPost]
  public IActionResult CreateProduct([FromBody] Product product)
  {
    var productId = _productService.CreateProduct(product);
    return Ok(productId);
  }

  [HttpGet("{productId}")]
  public IActionResult GetProductById(Guid productId)
  {
    var product = _productService.GetProductById(productId);
    if (product == null)
    {
      return NotFound();
    }
    return Ok(product);
  }

  [HttpPut]
  public IActionResult UpdateProduct([FromBody] Product product)
  {
    _productService.UpdateProduct(product);
    return NoContent();
  }

  [HttpDelete("{productId}")]
  public IActionResult DeleteProduct(Guid productId)
  {
    _productService.DeleteProduct(productId);
    return NoContent();
  }
}
