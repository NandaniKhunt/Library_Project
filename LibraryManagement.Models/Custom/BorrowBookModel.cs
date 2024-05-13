using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Custom
{
   public class BorrowBookModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public string BookName { get; set; } 
        public string StudentName  { get; set; } 
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public bool IsBorrowed { get; set; }
        public System.DateTime BorrowDate { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public decimal PenaltyAmount { get; set; }
    }
}
