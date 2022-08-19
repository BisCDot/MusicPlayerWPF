using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWfpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            return Ok("[#B8^o&G{6U&n$#VF'(!}KTKfax8$((]#kh0,");
        }
    }
}