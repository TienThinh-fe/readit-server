using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.DataAccess;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class ResultController : Controller
    {
        [HttpGet]
        public ActionResult<List<Result>> getAllResult([FromBody] string userId)
        {
            List<Result> results = new List<Result>();

            var db = new ReadItContext();
            results = db.Results.ToList();

            if (results != null)
            {
                return Ok(new JsonResult(results));
            }else
            {
                return NotFound("NOT FOUND ANY RESULT");
            }
        }

        [HttpPost]
        public ActionResult addResult([FromBody] Result result)
        {
            var db = new ReadItContext();
            db.Results.Add(result);
            db.SaveChanges();
            return Ok();
        }
    }
}
