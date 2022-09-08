using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Security.Claims;

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

        [Authorize]
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetModel resetModel)
        {
            try
            {
                var EmailId = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = this.iUserBl.ResetPassword(resetModel, EmailId);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = " Password reset succcessful" });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Password reset unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
