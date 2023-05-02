using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Course4_Net_MVC.Models
{
    public class CodeSerivce
    {
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        // where T : new() 是一個泛型約束, 指定 T 必須具有無參數的構造函數, 在方法內部就可以使用 new T() 來創建新的 T 類型的物件
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

        public List<SelectListItem> GetCodeDropDownItem(string tableName, string value, string text, string type = null)
        {
            DataTable dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append($"SELECT {text} AS Text, {value} AS Value FROM {tableName}");


            if (type != null)
            {
                sql.Append(" WHERE CODE_TYPE = @CodeType");
            }

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

                cmd.Parameters.Add(new SqlParameter("@CodeType", (object)type ?? DBNull.Value));

                SqlDataAdapter sqlDataAdpater = new SqlDataAdapter(cmd);
                sqlDataAdpater.Fill(dt);
                conn.Close();

                List<SelectListItem> result = MapDataToList<SelectListItem>(dt);

                return result;
            }
        }
    }
}