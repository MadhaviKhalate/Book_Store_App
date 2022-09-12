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
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL iaddressBL;
        public AddressController(IAddressBL iaddressBL)
        {
            this.iaddressBL = iaddressBL;
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "ID").Value);
                var result = iaddressBL.AddAddress(addressModel, UserID);
                if (result)
                {
                    return Ok(new { success = true, message = "Address Added successfully." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot add address." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateAddress(AddressModel addressModel, int AddressID)
        {
            try
            {
                var result = iaddressBL.UpdateAddress(addressModel, AddressID);
                if (result)
                {
                    return Ok(new { success = true, message = "Successfully updated address." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot update address." });
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
        public IActionResult GetAddress()
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "ID").Value);
                var result = iaddressBL.GetAddress(UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Address got successfully.", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot get address." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
