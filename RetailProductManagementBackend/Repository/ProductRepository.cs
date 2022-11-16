using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Web.Http;
using RetailProductManagementBackend.Model;

namespace RetailProductManagementBackend.Repository;

public class ProductRepository : BaseRepository, IProductRepository
{
    public static IEnumerable<Product> GetAllProducts()
    {
        var ProductList = new List<Product>();
        try
        {
            using var connection = new SQLiteConnection(GetConnectionString());
            connection.Open();
            var command = new SQLiteCommand("SELECT Id,Name,Price,Active,CreateDate,DeleteDate,ProductType FROM Product P INNER JOIN ProductType PT ON PT.ProductTypeId = P.Type", connection);
            using var rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                var product = new Product()
                {
                    Id = (long)rdr["Id"],
                    Name = rdr["Name"].ToString(),
                    Price = (double)rdr["Price"],
                    Active = (long)rdr["Active"] == 1,
                    ProductType = rdr["ProductType"].ToString(),
                };
                ProductList.Add(product);
            }

            rdr.Close();

            return ProductList;
        }
        catch (Exception e)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(e.Message)
            };
            throw new HttpResponseException(resp);
        }
    }

    public static Product UpdateProduct(Product product)
    {
        try
        {
            using var connection = new SQLiteConnection(GetConnectionString());
            connection.Open();
            var command = new SQLiteCommand("SELECT Id FROM Product WHERE Id = @ID LIMIT 1;", connection);
            command.Parameters.Add("@ID", DbType.Int64).Value = product.Id;
            using var rdr = command.ExecuteReader();
            if (rdr.HasRows) //Update
            {
                command.Parameters.Clear();
                command = new SQLiteCommand("UPDATE Product SET Name = @Name, Price = @Price, Active = @Active, Type = PT.ProductTypeId FROM ProductType PT Where PT.ProductType = @ProductType AND Product.Id = @ID", connection);
                command.Parameters.Add("@ID", DbType.Int64).Value = product.Id;
                command.Parameters.Add("@Name", DbType.String).Value = product.Name;
                command.Parameters.Add("@Price", DbType.Double).Value = product.Price;
                command.Parameters.Add("@Active", DbType.Int64).Value = product.Active ? 1 : 0;
                command.Parameters.Add("@ProductType", DbType.String).Value = product.ProductType;
                command.ExecuteNonQuery();
            }
            else //Create
            {
                command.Parameters.Clear();
                command = new SQLiteCommand("INSERT INTO Product (Name, Price, Active, Type, CreateDate) " +
                                            "VALUES (@Name, @Price, @Active, (SELECT ProductTypeId FROM ProductType WHERE ProductType = @ProductType), @CreateDate)", connection);
                command.Parameters.Add("@Name", DbType.String).Value = product.Name;
                command.Parameters.Add("@Price", DbType.Double).Value = product.Price;
                command.Parameters.Add("@Active", DbType.Int64).Value = product.Active ? 1 : 0;
                command.Parameters.Add("@ProductType", DbType.String).Value = product.ProductType;
                command.Parameters.Add("@CreateDate", DbType.DateTime).Value = DateTime.Now;
                command.ExecuteNonQuery();
            }

            return product;
        }
        catch (Exception e)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotModified)
            {
                Content = new StringContent(e.Message)
            };
            throw new HttpResponseException(resp);
        }
    }

    public static void DeleteProduct(int id)
    {
        try
        {
            using var connection = new SQLiteConnection(GetConnectionString());
            connection.Open();
            var command = new SQLiteCommand("DELETE FROM Product WHERE Id = @Id", connection);
            command.Parameters.Add("@Id", DbType.Int64).Value = id;
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotImplemented)
            {
                Content = new StringContent(e.Message)
            };
            throw new HttpResponseException(resp);
        }
    }
}