using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace bookService
{
    public class CodeService : ICodeService
    {
        private bookDao.ICodeDao codeDao { get; set; }

        public T MapDataToObject<T>(DataTable table) where T : new()
        {
            T myObject = codeDao.MapDataToObject<T>(table);

            return myObject;
        }

        public List<T> MapDataToList<T>(DataTable table) where T : new()
        {
            List<T> myList = codeDao.MapDataToList<T>(table);

            return myList;
        }

        public List<SelectListItem> GetCodeDropDownItem(string tableName, string value, string text, string type = null)
        {

            return codeDao.GetCodeDropDownItem(tableName, value, text, type);
        }
    }
}

