using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

        [Route("testException")]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
