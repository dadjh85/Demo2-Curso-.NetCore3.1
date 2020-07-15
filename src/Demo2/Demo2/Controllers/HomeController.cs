using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}
