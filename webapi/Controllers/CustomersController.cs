using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpGet("{number:pesel}")]
        public IActionResult GetByPesel(string number)
        {
            return Ok($"Pesel {number}");
        }

        [HttpGet("{number:nip}")]
        public IActionResult GetByNip(string number)
        {
            return Ok($"Nip {number}");
        }



        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(id);
        }

    }
}