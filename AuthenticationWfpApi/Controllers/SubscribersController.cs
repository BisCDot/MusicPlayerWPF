using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAuthenWpf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        [HttpGet, Authorize(Roles = "Subscriber")]
        public IActionResult Get()
        {
            return Ok("83h99UnCVN}.~1=AG]NU0gEekmqckTi&mDmEWByMw)");
        }
    }
}