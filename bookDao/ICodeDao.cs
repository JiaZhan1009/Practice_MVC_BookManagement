using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace bookDao
{
    public interface ICodeDao
    {
        List<SelectListItem> GetCodeDropDownItem(string tableName, string value, string text, string type = null);
        List<T> MapDataToList<T>(DataTable table) where T : new();
        T MapDataToObject<T>(DataTable table) where T : new();


    }
}