using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookModel
{
    public class LendRecord
    {
        public DateTime BookLendDate { get; set; }
        public string UserId { get; set; }
        public string UserCName { get; set; }
        public string UserEName { get; set; }
        public string BookName { get; set; }
        public string BookStatusId { get; set; }
    }
}