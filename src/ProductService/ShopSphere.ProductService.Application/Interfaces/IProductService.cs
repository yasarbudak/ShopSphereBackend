using ShopSphere.ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.ProductService.Application.Interfaces
{
  public interface IProductService
  {
    Guid CreateProduct(Product product);
    void UpdateProduct(Product product);
    Product GetProductById(Guid productId);
    void DeleteProduct(Guid productId);
  }
}
