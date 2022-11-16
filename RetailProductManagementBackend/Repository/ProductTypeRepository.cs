using System.Data.SQLite;
using System.Net;
using System.Web.Http;
using RetailProductManagementBackend.Model;

namespace RetailProductManagementBackend.Repository;

public class ProductTypeRepository : BaseRepository, IProductTypeRepository
{
    public static IEnumerable<ProductType> GetAllProductTypes()
    {
        var ProductTypeList = new List<ProductType>();
        try
        {
            using var connection = new SQLiteConnection(GetConnectionString());
            connection.Open();
            var command = new SQLiteCommand("SELECT ProductTypeId, ProductType FROM ProductType", connection);
            using var rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                var productType = new ProductType()
                {
                    ProductTypeId = (long)rdr["ProductTypeId"],
                    ProductTypeName = rdr["ProductType"].ToString()
                };
                ProductTypeList.Add(productType);
            }

            rdr.Close();
            return ProductTypeList;
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
}