using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //   return View();
        //}
       
            private readonly IUserBL iUserBl;

            public UserController(IUserBL iUserBl)
            {
                this.iUserBl = iUserBl;
            }

            [HttpPost]
            [Route("Register")]
            public IActionResult Registration([FromBody] RegisterModel userRegistration)
            {
                try
                {
                    var result = this.iUserBl.Registration(userRegistration);
                    if (result != null)
                    {
                        return Ok(new { success = true, message = "Registration Successfull" });
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "Registration UnSuceessfull" });
                    }
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
    }
}
