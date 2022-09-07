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

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var result = this.iUserBl.Login(loginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login Successfull" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login UnSuceessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword([FromBody] string EmailId)
        {
            try
            {
                var result = this.iUserBl.ForgetPassword(EmailId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Mail Sent Successful" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Mail UnSuceessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
