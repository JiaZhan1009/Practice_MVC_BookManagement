using bookModel;
using PagedList;
using System.Collections.Generic;

namespace bookModel
{
    public class BookViewModel
    {
        private int pageNumber;

        public BookViewModel()
        {

        }

        public BookViewModel(int pageNumber)
        {
            PageSize = 10;
            PageNumber = pageNumber;
            Book = new Book();
        }

        public int PageNumber
        {
            get { return pageNumber; }
            set
            {
                if (value < 1)
                    pageNumber = 1;
                else
                    pageNumber = value;
            }
        }
        public IPagedList<Book> PagedBooks { get; set; }
        public int PageSize { get; set; }
        public Book Book { get; set; }
        public List<LendRecord> LendRecords { get; set; }
    }
}