using bookModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookDao
{
    public class BookTestDao : IBookDao
    {
        public List<bookModel.Book> GetBooksByConditionOrAll(bookModel.Book book)
        {
            var result = new List<bookModel.Book>();

            result.Add(new bookModel.Book
            {
                BookId = 1,
                BookClassId = "BK",
                BookClassName = "bbb",
                BookName = "書名1",
                BookStatusId = "A",
                BookStatusDesc = "可以借出",
                UserId = "0001"
            });

            result.Add(new bookModel.Book
            {
                BookId = 2,
                BookClassId = "BK",
                BookClassName = "bbb",
                BookName = "書名2",
                BookStatusId = "A",
                BookStatusDesc = "可以借出",
                UserId = "0001"
            });

            return result;
        }
        public bool Destroy(int bookId)
        {
            return true;
        }

        public Book GetBookById(int bookId)
        {
            return new bookModel.Book
            {
                BookId = 1,
                BookClassId = "BK",
                BookClassName = "bbb",
                BookName = "書名1",
                BookStatusId = "A",
                BookStatusDesc = "可以借出",
                UserId = "0001"
            };
        }

        public List<LendRecord> GetLendRecord(int bookId)
        {
            var result = new List<bookModel.LendRecord>();

             result.Add(new bookModel.LendRecord
            {
                BookName = "書名1",
                BookStatusId = "A",
                UserId = "0001",
                BookLendDate = DateTime.Now,
                UserCName = "測試",
                UserEName = "TEST"
            });
            result.Add(new bookModel.LendRecord
            {
                BookName = "書名1",
                BookStatusId = "B",
                UserId = "0001",
                BookLendDate = DateTime.Now,
                UserCName = "測試",
                UserEName = "TEST"
            });

            return result;
        }

        public bool InsertBook(InsertBook book)
        {
            return true;
        }

        public bool UpdateBookByEdit(Book book)
        {
            return true;
        }
    }
}
