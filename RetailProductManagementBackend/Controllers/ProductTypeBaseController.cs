using Microsoft.AspNetCore.Mvc;

namespace RetailProductManagementBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductTypeBaseController : BaseController
{
    public ProductTypeBaseController(ILogger<BaseController> logger) : base(logger)
    {
    }
}