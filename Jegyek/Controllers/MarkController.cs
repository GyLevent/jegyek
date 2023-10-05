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
        public ActionResult<IEnumerable<CreateMark>> Get()
        {
            try
            {
                connect.Connection.Open();
                List<CreateMark> jegyek = new List<CreateMark>();
                string sql = $"Select * From jegyek";
                MySqlCommand Command = new MySqlCommand(sql, connect.Connection);
                var olv = Command.ExecuteReader();
                while (olv.Read())
                {
                    string Id = olv.GetString(0);
                    int Mark = olv.GetInt16(1);
                    string Description = olv.GetString(2);
                    DateTime CreatedTime = olv.GetDateTime(3);
                    jegyek.Add(new CreateMark(Guid.Parse(Id), Mark, Description, CreatedTime.ToString()));
                }

                connect.Connection.Close();
                return jegyek;
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public ActionResult<CreateMark> GetMark(Guid Id)
        {
            try
            {
                connect.Connection.Open();
                string sql = $"Select * From jegyek Where Id = '{Id}'";
                MySqlCommand Command = new MySqlCommand(sql, connect.Connection);
                var olv = Command.ExecuteReader();
                while (olv.Read())
                {
                    string id = olv.GetString(0);
                    int Mark = olv.GetInt16(1);
                    string Description = olv.GetString(2);
                    DateTime CreatedTime = olv.GetDateTime(3);
                    return new CreateMark(Guid.Parse(id), Mark, Description, CreatedTime.ToString());
                }
                connect.Connection.Close();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [HttpPut]
        [HttpDelete]




    }
}
