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
        public ActionResult<List<Result>> getAllResult(string userId)
        {
            List<Result> results = new List<Result>();

            var db = new ReadItContext();
            results = db.Results.Where(result => result.UserId == userId).ToList();

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

        [HttpDelete]
        public ActionResult deleteResult(int id)
        {
            var db = new ReadItContext();
            Result deleteResult = new Result();
            if (db.Results.SingleOrDefault(result => result.Id == id) != null)
            {
                deleteResult = db.Results.SingleOrDefault(result => result.Id == id);
                db.Results.Remove(deleteResult);
                db.SaveChanges();
                return Ok("DELETE SUCCESSFULLY");
            };
            return NotFound("RESULT DOES NOT EXIST");
        }
    }
}
