using RetailProductManagementBackend.Model;

namespace RetailProductManagementBackend.Repository;

public interface IProductRepository
{
    static IEnumerable<Product> GetAllProducts() => throw new NotImplementedException();
    static Product UpdateProduct(Product product) => throw new NotImplementedException();
    static void DeleteProduct(int id) => throw new NotImplementedException();
}