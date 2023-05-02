using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace bookService
{
    public interface ICodeService
    {
        List<SelectListItem> GetCodeDropDownItem(string tableName, string value, string text, string type = null);
        List<T> MapDataToList<T>(DataTable table) where T : new();
        T MapDataToObject<T>(DataTable table) where T : new();
    }
}