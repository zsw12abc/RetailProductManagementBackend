using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RetailProductManagementBackend.Model;
using RetailProductManagementBackend.Repository;

namespace RetailProductManagementBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("MyPolicy")]
public class ProductTypeController : ProductTypeBaseController
{
    public ProductTypeController(ILogger<BaseController> logger) : base(logger)
    {
    }
    
    [EnableCors("MyPolicy")]
    [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetAllProductTypes")]
    public IEnumerable<ProductType> Get()
    {
        var productTypes = ProductTypeRepository.GetAllProductTypes();
        return productTypes;
    }
}