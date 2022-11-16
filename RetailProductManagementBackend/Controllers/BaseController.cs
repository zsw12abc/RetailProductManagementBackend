using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace RetailProductManagementBackend.Controllers;
[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class BaseController : ControllerBase
{
    // GET
    private readonly ILogger<BaseController> _logger;

    public BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }
}