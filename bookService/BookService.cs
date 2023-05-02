using System.Collections.Generic;
using bookDao;
using bookModel;

namespace bookService
{
    /// <summary>
    /// 處理圖書新刪修服務
    /// </summary>
    public class BookService : IBookService
    {

        private bookDao.IBookDao bookDao { get; set; }
        public BookService()
        {
           
        }

        public BookService(IBookDao bookDao)
        {
            this.bookDao = bookDao;
        }

        public IBookDao GetBookDao() { return bookDao; }   

        public List<Book> GetBooksByConditionOrAll(Book book)
        {
            // 工廠模式
            //BookFactory bookFactory = new BookFactory();
            //bookDao.IBookDao bookDao = bookFactory.GetBookDao();

            return bookDao.GetBooksByConditionOrAll(book);
        }
        public Book GetBookById(int bookId)
        {

            return bookDao.GetBookById(bookId);
        }
        public bool UpdateBookByEdit(Book book)
        {

            return bookDao.UpdateBookByEdit(book);
        }
        public bool InsertBook(InsertBook book)
        {

            return bookDao.InsertBook(book);
        }

        public bool Destroy(int bookId)
        {

            return bookDao.Destroy(bookId);
        }

        public List<LendRecord> GetLendRecord(int bookId)
        {

            return bookDao.GetLendRecord(bookId);
        }
    }
}