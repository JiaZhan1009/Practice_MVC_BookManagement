using bookDao;
using bookModel;
using System.Collections.Generic;

namespace bookService
{
    
    public interface IBookService
    {
        bool Destroy(int bookId);
        Book GetBookById(int bookId);
        List<Book> GetBooksByConditionOrAll(Book book);
        List<LendRecord> GetLendRecord(int bookId);
        bool InsertBook(InsertBook book);
        bool UpdateBookByEdit(Book book);

        IBookDao GetBookDao();
    }
}