using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UseAspNetCoreInWpf.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                Fuck = "You world"
            };
        }
    }
}
