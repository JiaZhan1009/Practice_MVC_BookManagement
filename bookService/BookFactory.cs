using bookDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookService
{
    class BookFactory
    {
        public IBookDao GetBookDao()
        {
            IBookDao result;

            switch (bookCommon.ConfigTool.GetAppsetting("DaoInTest"))
            {
                case "Y":
                    result = new bookDao.BookTestDao();
                    break;
                case "N":
                    result = new bookDao.BookDao();
                    break;
                default:
                    result = new bookDao.BookTestDao();
                    break;
            }
            return result;
        }
    }
}
