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

        public BookModel UpdateBook(BookModel bookModel)
        {
            try
            {
                return this.ibookRL.UpdateBook(bookModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string DeleteBook(int BookId)
        {
            try
            {
                return this.ibookRL.DeleteBook(BookId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BookModel> GetAllBooks()
        {
            try
            {
                return this.ibookRL.GetAllBooks();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BookModel GetBookById(int BookId)
        {
            try
            {
                return this.ibookRL.GetBookById(BookId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
