using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course4_Net_MVC.Models
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

        //public List<SelectListItem> BookClasses { get; set; }
        //public List<SelectListItem> BookStatuses { get; set; }
        //public List<SelectListItem> Members { get; set; }
    }
}