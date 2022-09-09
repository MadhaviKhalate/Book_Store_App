using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IBookBL
    {
        public BookModel AddBook(BookModel bookModel);
        public BookModel UpdateBook(BookModel bookModel);
        public string DeleteBook(int BookId);
        public List<BookModel> GetAllBooks();
        public BookModel GetBookById(int BookId);

    }
}
