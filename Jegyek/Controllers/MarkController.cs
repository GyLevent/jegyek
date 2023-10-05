using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Jegyek.Models;
using static Jegyek.DTOS;

namespace Jegyek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        Connect connect = new Connect();
        [HttpGet]

        [HttpGet("{Id}")]
        [HttpPost]
        [HttpPut]
        [HttpDelete]




    }
}
