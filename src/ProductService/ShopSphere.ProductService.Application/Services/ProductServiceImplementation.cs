using ShopSphere.ProductService.Application.Interfaces;
using ShopSphere.ProductService.Domain.Entities;
using ShopSphere.ProductService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.ProductService.Application.Services
{
  public class ProductServiceImplementation : IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductServiceImplementation(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public Guid CreateProduct(Product product)
    {
      // Business logic (örneğin, stok kontrolü veya fiyat doğrulaması)
      if (product.Price <= 0)
        throw new ArgumentException("Price must be greater than zero.");

      if (product.Stock < 0)
        throw new ArgumentException("Stock cannot be negative.");

      return _productRepository.CreateProduct(product);
    }

    public void UpdateProduct(Product product)
    {
      if (product.Price <= 0)
        throw new ArgumentException("Price must be greater than zero.");

      _productRepository.UpdateProduct(product);
    }

    public Product GetProductById(Guid productId)
    {
      var product = _productRepository.GetProductById(productId);
      if (product == null)
        throw new KeyNotFoundException("Product not found.");

      return product;
    }

    public void DeleteProduct(Guid productId)
    {
      var product = _productRepository.GetProductById(productId);
      if (product == null)
        throw new KeyNotFoundException("Product not found.");

      _productRepository.DeleteProduct(productId);
    }
  }
}
