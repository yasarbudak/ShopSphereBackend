using Microsoft.EntityFrameworkCore;
using Moq;
using ShopSphere.ProductService.Application.Services;
using ShopSphere.ProductService.Domain.Entities;
using ShopSphere.ProductService.Domain.Interfaces;
using ShopSphere.ProductService.Persistence.DbContexts;
using ShopSphere.ProductService.Persistence.Repositories;
using Xunit;


namespace ShopSphere.ProductServiceTests
{
  public class ProductRepositoryTests
  {
    private readonly Mock<ProductDbContext> _mockTestContext;
    private readonly Mock<DbSet<Product>> _mockSet;
    private readonly ProductRepository _productRepository;

    [Fact]
    public void CreateProduct_ShouldReturnGuid_WhenProductIsValid()
    {
      // Arrange
      var mockRepository = new Mock<IProductRepository>();
      var product = new Product
      {
        ProductId = Guid.NewGuid(),
        Name = "Sample Product",
        Description = "This is a test product.",
        Price = 100m,
        Stock = 10
      };

      mockRepository.Setup(repo => repo.CreateProduct(It.IsAny<Product>()))
                    .Returns(product.ProductId);

      var service = new ProductServiceImplementation(mockRepository.Object);

      // Act
      var result = service.CreateProduct(product);

      // Assert
      Assert.AreNotEqual(Guid.Empty, result);
      mockRepository.Verify(repo => repo.CreateProduct(It.IsAny<Product>()), Times.Once());
    }

    [Fact]
    public void GetProductById_ShouldReturnProduct_WhenProductExists()
    {
      // Arrange
      var mockRepository = new Mock<IProductRepository>();
      var productId = Guid.NewGuid();
      var product = new Product
      {
        ProductId = productId,
        Name = "Sample Product",
        Description = "This is a test product.",
        Price = 100m,
        Stock = 10
      };

      mockRepository.Setup(repo => repo.GetProductById(productId)).Returns(product);

      var service = new ProductServiceImplementation(mockRepository.Object);

      // Act
      var result = service.GetProductById(productId);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(productId, result.ProductId);
      mockRepository.Verify(repo => repo.GetProductById(productId), Times.Once());
    }

    [Fact]
    public void UpdateProduct_ShouldCallRepository_WhenProductIsValid()
    {
      // Arrange
      var mockRepository = new Mock<IProductRepository>();
      var product = new Product
      {
        ProductId = Guid.NewGuid(),
        Name = "Updated Product",
        Description = "This product has been updated.",
        Price = 120m,
        Stock = 15
      };

      var service = new ProductServiceImplementation(mockRepository.Object);

      // Act
      service.UpdateProduct(product);

      // Assert
      mockRepository.Verify(repo => repo.UpdateProduct(It.IsAny<Product>()), Times.Once());
    }

    [Fact]
    public void DeleteProduct_ShouldCallRepository_WhenProductExists()
    {
      // Arrange
      var mockRepository = new Mock<IProductRepository>();
      var productId = Guid.NewGuid();

      mockRepository.Setup(repo => repo.GetProductById(productId))
                    .Returns(new Product { ProductId = productId });

      var service = new ProductServiceImplementation(mockRepository.Object);

      // Act
      service.DeleteProduct(productId);

      // Assert
      mockRepository.Verify(repo => repo.DeleteProduct(productId), Times.Once());
    }

  }
}
