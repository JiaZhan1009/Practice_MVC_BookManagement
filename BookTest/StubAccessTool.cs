using bookCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTest
{
    //internal class StubAccessTool : IDataAccessTool
    internal class StubAccessTool : DataAccessTool
    {
        public DataTable Query(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable returnValue = new DataTable();
            returnValue.Columns.Add(new DataColumn("BookId"));
            returnValue.Columns.Add(new DataColumn("BookAuthor"));
            returnValue.Columns.Add(new DataColumn("BookNote"));
            returnValue.Columns.Add(new DataColumn("BookClassId"));
            returnValue.Columns.Add(new DataColumn("BookClassName"));
            returnValue.Columns.Add(new DataColumn("BookName"));
            returnValue.Columns.Add(new DataColumn("BookBoughtDate"));
            returnValue.Columns.Add(new DataColumn("BookStatusId"));
            returnValue.Columns.Add(new DataColumn("UserId"));
            returnValue.Columns.Add(new DataColumn("UserCName"));
            returnValue.Columns.Add(new DataColumn("UserEName"));

            returnValue.Rows.Add(01, "BookAuthor", "BookNote", "BookClassId", "BookClassName");

            return returnValue;
        }
    }
}
