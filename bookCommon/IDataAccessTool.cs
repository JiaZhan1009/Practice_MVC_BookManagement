using System.Collections.Generic;
using System.Data;

namespace bookCommon
{
    public interface IDataAccessTool
    {
        string GetDBConnectionString();
        DataTable Query(string connStr, string sql, IList<KeyValuePair<string, object>> parameters);
    }
}