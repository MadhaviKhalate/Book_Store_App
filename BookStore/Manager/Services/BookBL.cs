using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Services
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL ibookRL;
        public BookBL(IBookRL ibookRL)
        {
            this.ibookRL = ibookRL;
        }

        public BookModel AddBook(BookModel bookModel)
        {
            try
            {
                return this.ibookRL.AddBook(bookModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
