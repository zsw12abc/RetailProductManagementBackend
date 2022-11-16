using System.Net;
using System.Text;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RetailProductManagementBackend.Model;
using RetailProductManagementBackend.Repository;


namespace RetailProductManagementBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ProductBaseController
{
    public ProductController(ILogger<BaseController> logger) : base(logger)
    {
    }
    
    [Microsoft.AspNetCore.Mvc.HttpGet(Name="GetAllProducts")]
    public IEnumerable<Product> Get()
    {
        var products = ProductRepository.GetAllProducts().ToList();
        return products;
    }
    
    [Microsoft.AspNetCore.Mvc.HttpPut("UpdateProduct")]
    public HttpResponseMessage Put([System.Web.Http.FromBody] Product product)
    {
        ProductRepository.UpdateProduct(product);
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
    
    [Microsoft.AspNetCore.Mvc.HttpDelete("DeleteProduct/{id:int}")]
    public HttpResponseMessage Delete([FromUri] int id)
    {
        ProductRepository.DeleteProduct(id);
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
}