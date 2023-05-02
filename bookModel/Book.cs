using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace bookModel
{
    public class Book
    {

        [DisplayName("書籍編號")]
        public int BookId { get; set; }

        [DisplayName("書名")]
        [StringLength(200, ErrorMessage = "書名不可超過200個字")]
        [Required(ErrorMessage = "書名為必填")]
        public string BookName { get; set; }

        [DisplayName("類別編號")]
        [Required(ErrorMessage = "請選擇一個有效的選項")]
        public string BookClassId { get; set; }

        [DisplayName("圖書類別")]
        public string BookClassName { get; set; }

        [DisplayName("作者")]
        [StringLength(30, ErrorMessage = "作者不可超過30個字")]
        [Required(ErrorMessage = "作者為必填")]
        public string BookAuthor { get; set; }

        [DisplayName("購書日期")]
        [Required(ErrorMessage = "購書日期為必填")]
        public DateTime BookBoughtDate { get; set; }

        [DisplayName("狀態編號")]
        [Required(ErrorMessage = "請選擇一個有效的選項")]
        public string BookStatusId { get; set; }

        [DisplayName("借閱狀態")]
        public string BookStatusDesc { get; set; }

        [DisplayName("出版商")]
        [StringLength(20, ErrorMessage = "出版商不可超過20個字")]
        [Required(ErrorMessage = "出版商為必填")]
        public string BookPublisher { get; set; }

        [DisplayName("內容簡介")]
        [StringLength(1200, ErrorMessage = "內容簡介不可超過1200個字")]
        [Required(ErrorMessage = "內容簡介為必填")]
        public string BookNote { get; set; }

        [DisplayName("會員編號")]
        //[Required(ErrorMessage = "請選擇一個有效的選項")]
        public string UserId { get; set; }

        [DisplayName("借閱人")]
        public string UserEName { get; set; }

        [DisplayName("借閱人")]
        public string UserCName { get; set; }
    }
}