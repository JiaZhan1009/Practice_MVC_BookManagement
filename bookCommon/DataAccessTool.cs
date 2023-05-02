using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace bookCommon
{
    public class DataAccessTool : IDataAccessTool
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>
        public string GetDBConnectionString()
        {
            return ConfigTool.GetDBConnectionString("DBConn");
        }

        public DataTable Query(string connStr, string sql, IList<KeyValuePair<string, object>> parameters)
        {
            connStr = string.IsNullOrEmpty(connStr) ? this.GetDBConnectionString() : connStr;

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        public bool Destroy(bool bookIsLend)
        {
            

            return true;
        }

        public bool InsertBook(string connStr, string sql, IList<KeyValuePair<string, object>> parameters)
        {


            return true;
        }
    }
}

