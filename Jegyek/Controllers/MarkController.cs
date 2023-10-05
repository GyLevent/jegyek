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
        public ActionResult<Marks> Post(CreateMark createMark)
        {
            DateTime dateTime = DateTime.Now;
            string timenow = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            var NewMark = new Marks
            {
                Id = Guid.NewGuid(),
                Mark = createMark.Mark,
                Description = createMark.Description,
                CreatedTime = timenow
            };
            try
            {
                connect.Connection.Open();
                string sqlinput = $"INSERT INTO jegyek(Id,Mark,Description,CreatedTime) VALUES ('{NewMark.Id}','{NewMark.Mark}','{NewMark.Description}','{NewMark.CreatedTime}'";
                MySqlCommand command = new MySqlCommand(sqlinput, connect.Connection);
                command.ExecuteNonQuery();
                connect.Connection.Close();
                return StatusCode(201, NewMark);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]

        [HttpDelete("{Id}")]




    }
}
