using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace RetailProductManagementBackend.Controllers;

public class BaseController : ApiController
{
    // GET
    private readonly ILogger<BaseController> _logger;

    public BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }
}