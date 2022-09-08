using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;

namespace BookStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [HttpPost("AddBook")]
        public ActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var book = this.bookBL.AddBook(bookModel);
                if (book != null)
                {
                    return this.Ok(new { success = true, message = "Book added successfully", data = book });
                }
                return this.BadRequest(new { success = false, message = "Failed to add book", data = book });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
