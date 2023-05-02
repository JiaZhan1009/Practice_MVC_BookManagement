//using BookSystem.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace bookDao
{
    public class CodeTestDao : ICodeDao
    {
        private string rootCodeDataFilePath = @"C:\Users\kayden_tsai\Desktop\Kayden\GitLab\course6\Section1\Course6_BackEnd\bookDao\DataFile\";

        public T MapDataToObject<T>(DataTable table) where T : new()
        {
            // GetProperty 可加參數找 BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance

            DataRow row = table.Rows[0];

            T item = new T();

            foreach (DataColumn column in table.Columns)
            {
                // 獲取列名對應的屬性
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);

                // property 代表屬性, 如果該列有資料不為 DBNull，則設置屬性值
                if (property != null && row[column] != DBNull.Value)
                {
                    // property.SetValue(處理物件, 設定資料, 索引選擇器)
                    property.SetValue(item, row[column], null);
                }
            }

            return item;
        }

        public List<T> MapDataToList<T>(DataTable table) where T : new()
        {
            List<T> result = new List<T>();

            // 逐筆讀取 DataTable 中的每一行資料
            foreach (DataRow row in table.Rows)
            {
                T item = new T();
                foreach (DataColumn column in table.Columns)
                {
                    PropertyInfo property = item.GetType().GetProperty(column.ColumnName);
                    if (property != null && row[column] != DBNull.Value)
                    {
                        property.SetValue(item, row[column], null);
                    }
                }
                result.Add(item);
            }

            return result;
        }

        public List<SelectListItem> GetCodeDropDownItem(string tableName, string value, string text, string status)
        {
            string bookCodeFilePath = $"{rootCodeDataFilePath}{tableName}.txt";

            var lines = File.ReadAllLines(bookCodeFilePath);
            List<SelectListItem> result = new List<SelectListItem>();
            string splitChar = "\t";

            foreach (var item in lines)
            {
                if (item.Split(splitChar.ToCharArray())[0] != status)
                {
                    if(tableName == "BOOK_CODE" && tableName != "MEMBER_M")
                    {
                        result.Add(new SelectListItem()
                        {
                            Text = item.Split(splitChar.ToCharArray())[3],
                            Value = item.Split(splitChar.ToCharArray())[1]
                        });
                    }
                    else
                    {
                        result.Add(new SelectListItem()
                        {
                            Text = item.Split(splitChar.ToCharArray())[1],
                            Value = item.Split(splitChar.ToCharArray())[0]
                        });
                    }
                }

            }
            return result;
        }
    }
}
