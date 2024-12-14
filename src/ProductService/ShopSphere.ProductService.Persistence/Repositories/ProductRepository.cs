using ShopSphere.ProductService.Domain.Entities;
using ShopSphere.ProductService.Domain.Interfaces;
using ShopSphere.ProductService.Persistence.DbContexts;

namespace ShopSphere.ProductService.Persistence.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly ProductDbContext _productDbContext;

    public ProductRepository(ProductDbContext productDbContext)
    {
      _productDbContext = productDbContext;
    }
    public Guid CreateProduct(Product product)
    {
      _productDbContext.Products.Add(product);
      _productDbContext.SaveChanges();
      return product.ProductId;
    }

    public void DeleteProduct(Guid productId)
    {
      var product = _productDbContext.Products.Find(productId);
      if (product != null)
      {
        _productDbContext.Products.Remove(product);
        _productDbContext.SaveChanges();
      }
    }

    public Product GetProductById(Guid productId)
    {
      return _productDbContext.Products.Find(productId);
    }

    public void UpdateProduct(Product product)
    {
      _productDbContext.Products.Update(product);
      _productDbContext.SaveChanges(true);
    }
  }
}
