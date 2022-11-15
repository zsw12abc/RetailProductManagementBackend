using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Http;
using Microsoft.AspNetCore.Mvc;
using RetailProductManagementBackend.Model;

namespace RetailProductManagementBackend.Controllers;

[ApiController]
public class ProductController : ProductBaseController
{
    public ProductController(ILogger<BaseController> logger) : base(logger)
    {
    }

    [Microsoft.AspNetCore.Mvc.HttpGet]
    [GET("GetAllProducts")]
    public IEnumerable<Product> Get()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Product1",
            Price = 121,
            ProductType = "Food",
            Active = false,
            CreateDate = DateTime.Now,
            DeleteDate = null
        };
        return new[] { product };
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    [POST("UpdateProduct")]
    public void Post([Microsoft.AspNetCore.Mvc.FromBody] Product product)
    {
    }

    [Microsoft.AspNetCore.Mvc.HttpDelete]
    [DELETE("DeleteProduct/{id}")]
    public void Delete([FromUri] int id)
    {
    }
}