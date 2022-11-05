using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [HttpPost("PlaceOrder")]
        public IActionResult AddOrder(OrderModel order)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ID").Value);
                var result = this.orderBL.AddOrder(order, UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Order placed Successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Order failed" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int OrderId)
        {
            try
            {
                var result = this.orderBL.DeleteOrder(OrderId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Order Deleted Successfully", });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Deletion Failed" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public IActionResult GetOrder()
        {
            try
            {
                var result = orderBL.GetAllOrders();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Orders got successfully.", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot get order." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
