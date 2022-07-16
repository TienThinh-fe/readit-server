using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.DataAccess;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult addUser([FromBody] User newUser)
        {
            var db = new ReadItContext();
            bool userExisted = false;

            if (db.Users.SingleOrDefault(user => user.Id == newUser.Id) != null)
            {
                userExisted = true;
            }

            if (userExisted == false)
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return new JsonResult("USER EXISTED");
            }
        }

        [HttpGet]
        public ActionResult test()
        {
            return new JsonResult("ABC");
        }
    }
}
