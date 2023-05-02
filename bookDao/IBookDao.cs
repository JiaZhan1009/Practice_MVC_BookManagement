using bookModel;
using System.Collections.Generic;

namespace bookDao
{
    public interface IBookDao
    {
        bool Destroy(int bookId);
        Book GetBookById(int bookId);
        List<Book> GetBooksByConditionOrAll(Book book);
        List<LendRecord> GetLendRecord(int bookId);
        bool InsertBook(InsertBook book);
        bool UpdateBookByEdit(Book book);
    }
}