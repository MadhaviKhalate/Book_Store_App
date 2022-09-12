using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBL ifeedbackBL;
        public FeedbackController(IFeedbackBL ifeedbackBL)
        {
            this.ifeedbackBL = ifeedbackBL;
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "ID").Value);
                var result = ifeedbackBL.AddFeedback(feedbackModel, UserID);
                if (result)
                {
                    return Ok(new { success = true, message = "Feedback added successfully." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot add feedback." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Get")]
        public IActionResult GetFeedback()
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "ID").Value);
                var result = ifeedbackBL.GetFeedback(UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Feedback got successfully.", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot get feedback." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
