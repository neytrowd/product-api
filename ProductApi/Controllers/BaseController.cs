using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ProductApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class BaseController : Controller
    {
        
    }
}