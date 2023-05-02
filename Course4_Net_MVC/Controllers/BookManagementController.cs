using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using bookService;
using bookCommon;
using bookModel;

namespace Course4_Net_MVC.Controllers
{
    public class BookManagementController : Controller
    {
        private ICodeService codeService { get; set; }
        private IBookService bookService { get; set; }
        public BookManagementController()
        {
           
        }
        public BookManagementController(IBookService _bookService)
        {
            bookService = _bookService;
        }
        public ActionResult Index(int? page)
        {
            try
            {
                //int i = 0;
                //int j = 1 / i;

                List<Book> books = bookService.GetBooksByConditionOrAll(new bookModel.Book());

                GetAllDropDownList();

                BookViewModel bookViewModel = new BookViewModel(page ?? 1);

                bookViewModel.PagedBooks = books.ToPagedList(bookViewModel.PageNumber, bookViewModel.PageSize);
                return View(bookViewModel);
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Search(bookModel.Book book, int? page)
        {
            try
            {
                List<bookModel.Book> books = bookService.GetBooksByConditionOrAll(book);

                GetAllDropDownList();

                bookModel.BookViewModel bookViewModel = new bookModel.BookViewModel(page ?? 1);

                bookViewModel.PagedBooks = books.ToPagedList(bookViewModel.PageNumber, bookViewModel.PageSize);

                return PartialView("_SearchResult", bookViewModel);
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return View("Error");
            }
        }

        public ActionResult LendRecord(int bookId)
        {
            try
            {
                List<bookModel.LendRecord> lendRecord = bookService.GetLendRecord(bookId);

                bookModel.BookViewModel bookViewModel = new bookModel.BookViewModel()
                {
                    LendRecords = lendRecord
                };

                return View(bookViewModel);
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Insert()
        {
            try
            {
                ViewBag.bookClasses = codeService.GetCodeDropDownItem("BOOK_CLASS", "BOOK_CLASS_ID", "BOOK_CLASS_NAME");

                bookModel.InsertBook book = new bookModel.InsertBook();

                return View(book);
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Insert(bookModel.InsertBook book)
        {
            try
            {
                ViewBag.BookClasses = codeService.GetCodeDropDownItem("BOOK_CLASS", "BOOK_CLASS_ID", "BOOK_CLASS_NAME");

                if (ModelState.IsValid)
                {
                    bool success = bookService.InsertBook(book);

                    if (success)
                    {
                        TempData["Message"] = "存檔成功!";
                        ModelState.Clear();
                        return View("Insert");
                    }
                    else
                    {
                        TempData["Message"] = "發生錯誤";

                        return View(book);
                    }
                }
                else
                {
                    TempData["Message"] = "請檢查欄位是否填寫正確";

                    return View(book);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public JsonResult Destroy(int bookId)
        {
            try
            {
                Book currentBook = bookService.GetBookById(bookId);

                if (currentBook.BookStatusId == "B" || currentBook.BookStatusId == "C")
                {
                    return Json(new { success = false, message = "此筆書籍資料最新狀態為已借出無法刪除" });
                }

                bool success = bookService.Destroy(bookId);

                if (success)
                {
                    return Json(new { success = true, message = "刪除成功！" });
                }
                else
                {
                    return Json(new { success = false, message = "系統發生問題" });
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return Json(new { success = false, message = "系統發生問題" });
            }
        }

        [HttpGet]
        public ActionResult Detail(int bookId)
        {
            try
            {
                GetAllDropDownList();

                var Book = bookService.GetBookById(bookId);

                return View(Book);
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Detail(bookModel.Book book)
        {
            try
            {
                GetAllDropDownList();

                bool success;

                Book currentBook = bookService.GetBookById(book.BookId);

                string currentStatusId = currentBook.BookStatusId;
                string currentUserId = currentBook.UserId;

                if (currentStatusId == book.BookStatusId && currentUserId == book.UserId)
                {
                    TempData["Message"] = "目前選擇的借閱狀態與最新資料相符, 無法存檔";

                    return View(book);
                }

                if (!ModelState.IsValid)
                {
                    TempData["Message"] = "請檢查欄位是否填寫正確";

                    return View(book);
                }

                if (book.UserId == null && book.BookStatusId == "B" || book.BookStatusId == "C")
                {   // 狀態為已借出、已借出（未領）, 且 user 為空

                    TempData["Message"] = "書籍狀態為已借出但未選擇借閱人！";

                    return View(book);
                }

                success = bookService.UpdateBookByEdit(book);

                if (success)
                {
                    TempData["Message"] = "存檔成功";

                    return View(book);
                }
                else
                {
                    TempData["Message"] = "操作失敗";

                    return View(book);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
                return View("Error");
            }
        }
        private void GetAllDropDownList()
        {
            try
            {
                ViewBag.BookClasses = codeService.GetCodeDropDownItem("BOOK_CLASS", "BOOK_CLASS_ID", "BOOK_CLASS_NAME");
                ViewBag.BookStatuses = codeService.GetCodeDropDownItem("BOOK_CODE", "CODE_ID", "CODE_NAME", "BLOOD_TYPE");
                ViewBag.Members = codeService.GetCodeDropDownItem("MEMBER_M", "USER_ID", "USER_ENAME + '-' + USER_CNAME");
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogCategoryEnum.Error, ex.ToString());
            }
        }

    }
}