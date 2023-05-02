using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Course4_Net_MVC.Models
{
    /// <summary>
    /// 處理圖書新刪修服務
    /// </summary>
    public class BookService
    {
        private readonly CodeSerivce _codeSerivce;

        public BookService()
        {
            _codeSerivce = new CodeSerivce();
        }
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        public List<Book> GetBooksByConditionOrAll(Book book)
        {
            DataTable dt = new DataTable();

            StringBuilder builder = new StringBuilder();

            string sql = @"
                	SELECT
		                BD.BOOK_ID AS BookId,
		                BC.BOOK_CLASS_ID AS BookClassId,
		                BC.BOOK_CLASS_NAME AS BookClassName,
		                BD.BOOK_NAME AS BookName,
		                BOOK_BOUGHT_DATE AS BookBoughtDate,
		                CODE.CODE_ID AS BookStatusId,
		                CODE.CODE_NAME AS BookStatusDesc,
		                M.USER_ENAME AS UserEName,
		                M.USER_ID AS UserId
	                FROM
		                BOOK_DATA AS BD 
	                INNER JOIN
		                BOOK_CLASS AS BC
			                ON BD.BOOK_CLASS_ID = BC.BOOK_CLASS_ID
	                INNER JOIN
		                BOOK_CODE AS CODE
			                ON BD.BOOK_STATUS = CODE.CODE_ID
	                LEFT JOIN 	
		                MEMBER_M AS M 
			                ON M.USER_ID = BD.BOOK_KEEPER
	                WHERE
		                CODE.CODE_TYPE = 'BOOK_STATUS'";

            builder.Append(sql);

            if (book.BookName != "" && book.BookName != null)
                builder.Append(" AND BD.BOOK_NAME LIKE '%' + @BookName + '%'");
            if (book.BookClassId != "" && book.BookClassId != null)
                builder.Append(" AND BC.BOOK_CLASS_ID = @BookClassId");
            if (book.BookStatusId != "" && book.BookStatusId != null)
                builder.Append(" AND CODE.CODE_ID = @BookStatusId");
            if (book.UserId != "" && book.UserId != null)
                builder.Append(" AND M.USER_ID = @UserId");

            builder.Append(" ORDER BY BOOK_BOUGHT_DATE;");

            Debug.WriteLine(builder.ToString());

            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(builder.ToString(), conn);
                cmd.Parameters.Add(new SqlParameter("@BookName", (object)book.BookName ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@BookClassId", (object)book.BookClassId ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@BookStatusId", (object)book.BookStatusId ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@UserId", (object)book.UserId ?? DBNull.Value));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }

            List<Book> result = _codeSerivce.MapDataToList<Book>(dt);

            return result;
        }

        public Book GetBookById(int bookId)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT
	                BD.BOOK_ID AS BookId,
	                BD.BOOK_AUTHOR AS BookAuthor,
	                BOOK_PUBLISHER AS BookPublisher,
	                BOOK_NOTE AS BookNote,
	                BC.BOOK_CLASS_ID AS BookClassId,
	                BC.BOOK_CLASS_NAME AS BookClassName,
	                BD.BOOK_NAME AS BookName,
	                BOOK_BOUGHT_DATE AS BookBoughtDate,
	                CODE.CODE_ID AS BookStatusId,
	                CODE.CODE_NAME AS BookStatusDesc,
                    USER_ID AS UserId,
                    USER_CNAME AS UserCName,
	                USER_ENAME AS UserEName
                FROM
	                BOOK_DATA AS BD 
                INNER JOIN
	                BOOK_CLASS AS BC
		                ON BD.BOOK_CLASS_ID = BC.BOOK_CLASS_ID
                INNER JOIN
	                BOOK_CODE AS CODE
		                ON BD.BOOK_STATUS = CODE.CODE_ID
                LEFT JOIN 	
	                MEMBER_M AS M 
		                ON M.USER_ID = BD.BOOK_KEEPER
                WHERE
	                CODE.CODE_TYPE = 'BOOK_STATUS' AND BD.BOOK_ID = @BookId
                ORDER BY
	                BOOK_BOUGHT_DATE;";

            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BookId", bookId));
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                sqlDataAdapter.Fill(dt);
            }

            Book book = _codeSerivce.MapDataToObject<Book>(dt);

            return book;
        }

        public bool UpdateBookByE1dit(Book book)
        {
            var sql = @" 
                UPDATE 
	                BOOK_DATA 
                SET 
	                BOOK_NAME = @bookName,
	                BOOK_CLASS_ID = @bookClassId,
	                BOOK_AUTHOR= @bookAuthor,
	                BOOK_BOUGHT_DATE= @bookBoughtDate,
	                BOOK_PUBLISHER= @bookPublisher,
	                BOOK_NOTE= @bookNote,
	                BOOK_STATUS= @bookStatusId,
	                BOOK_KEEPER= @userId
                WHERE 
	                BOOK_ID = @bookId;";
            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@bookName", book.BookName));
                cmd.Parameters.Add(new SqlParameter("@bookClassId", book.BookClassId));
                cmd.Parameters.Add(new SqlParameter("@bookAuthor", book.BookAuthor));
                cmd.Parameters.Add(new SqlParameter("@bookBoughtDate", book.BookBoughtDate));
                cmd.Parameters.Add(new SqlParameter("@bookPublisher", book.BookPublisher));
                cmd.Parameters.Add(new SqlParameter("@bookNote", book.BookNote));
                cmd.Parameters.Add(new SqlParameter("@bookStatusId", book.BookStatusId));
                cmd.Parameters.Add(new SqlParameter("@userId", (object)book.UserId ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@bookId", book.BookId));

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }

        public bool UpdateBookByEdit(Book book)
        {
            var sql = @" 
                BEGIN TRY
	                BEGIN TRANSACTION
		                UPDATE 
			                BOOK_DATA 
		                SET 
			                BOOK_NAME = @bookName,
			                BOOK_CLASS_ID = @bookClassId,
			                BOOK_AUTHOR= @bookAuthor,
			                BOOK_BOUGHT_DATE= @bookBoughtDate,
			                BOOK_PUBLISHER= @bookPublisher,
			                BOOK_NOTE= @bookNote,
			                BOOK_STATUS= @bookStatusId,
			                BOOK_KEEPER= @userId
		                WHERE 
			                BOOK_ID = @bookId";

            StringBuilder builder = new StringBuilder();

            builder.Append(sql);

            if (book.UserId != null)
            {
                builder.Append(" INSERT INTO BOOK_LEND_RECORD (BOOK_ID, KEEPER_ID, LEND_DATE) VALUES (@bookId, @userId, @LendDate)");
            }

            builder.Append(" COMMIT TRANSACTION END TRY BEGIN CATCH  ROLLBACK TRANSACTION END CATCH;");
            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(builder.ToString(), conn);
                cmd.Parameters.Add(new SqlParameter("@bookName", book.BookName));
                cmd.Parameters.Add(new SqlParameter("@bookClassId", book.BookClassId));
                cmd.Parameters.Add(new SqlParameter("@bookAuthor", book.BookAuthor));
                cmd.Parameters.Add(new SqlParameter("@bookBoughtDate", book.BookBoughtDate));
                cmd.Parameters.Add(new SqlParameter("@bookPublisher", book.BookPublisher));
                cmd.Parameters.Add(new SqlParameter("@bookNote", book.BookNote));
                cmd.Parameters.Add(new SqlParameter("@bookStatusId", book.BookStatusId));
                cmd.Parameters.Add(new SqlParameter("@userId", (object)book.UserId ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@bookId", book.BookId));
                cmd.Parameters.Add(new SqlParameter("@LendDate", DateTime.Now));

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
        }
        public bool InsertBook(InsertBook book)
        {
            var sql = @" 
                INSERT INTO 
                BOOK_DATA (
                    BOOK_NAME, BOOK_CLASS_ID,
                    BOOK_AUTHOR, BOOK_BOUGHT_DATE,
                    BOOK_PUBLISHER, BOOK_NOTE,
                    BOOK_STATUS
                )
                VALUES (
                    @bookName, @bookClassId,
                    @bookAuthor, @bookBoughtDate,
                    @bookPublisher, @bookNote,
                    'A'
                );";
            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@bookName", book.BookName));
                    cmd.Parameters.Add(new SqlParameter("@bookClassId", book.BookClassId));
                    cmd.Parameters.Add(new SqlParameter("@bookAuthor", book.BookAuthor));
                    cmd.Parameters.Add(new SqlParameter("@bookBoughtDate", book.BookBoughtDate));
                    cmd.Parameters.Add(new SqlParameter("@bookPublisher", book.BookPublisher));
                    cmd.Parameters.Add(new SqlParameter("@bookNote", book.BookNote));

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Destroy(int bookId)
        {
            string sql = @" DELETE BOOK_DATA WHERE BOOK_ID = @bookId;";

            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@bookId", bookId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        public List<LendRecord> GetLendRecord(int bookId)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT
	                BD.BOOK_NAME AS BookName,
	                BLR.LEND_DATE AS BookLendDate,
	                M.USER_CNAME AS UserCName,
	                M.USER_ENAME AS UserEName,
	                M.USER_ID AS UserId,
                    CODE.CODE_ID AS BookStatusId
                FROM
	                BOOK_LEND_RECORD AS BLR 
                INNER JOIN 	
	                MEMBER_M AS M 
		                ON BLR.KEEPER_ID = M.USER_ID 
		        INNER JOIN 	
	                BOOK_DATA AS BD 
		                ON BLR.BOOK_ID = BD.BOOK_ID
		        INNER JOIN 	
	                BOOK_CODE AS CODE 
		                ON BD.BOOK_STATUS = CODE.CODE_ID
                WHERE 
	                BLR.BOOK_ID = @BookId
                ORDER BY 
	                BookLendDate DESC;";

            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BookId", bookId));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }

            List<LendRecord> result = _codeSerivce.MapDataToList<LendRecord>(dt);

            return result;
        }
    }
}