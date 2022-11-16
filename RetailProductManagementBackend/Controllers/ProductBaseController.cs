using Microsoft.AspNetCore.Mvc;

namespace RetailProductManagementBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductBaseController : BaseController
{
    public ProductBaseController(ILogger<BaseController> logger) : base(logger)
    {
    }
}