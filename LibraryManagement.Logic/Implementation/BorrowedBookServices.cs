using LibraryManagement.Logic.Interface;
using LibraryManagement.Models;
using LibraryManagement.Models.Custom;
using LibraryManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Logic.Implementation
{
    public class BorrowedBookServices : BaseServices,IBorrowedBook
    {
        public List<BorrowBookModel> GetBorrowedBook()
        {
            var listResult = (from br in db.BorrowedBook
                                          join b in db.Book on br.BookId equals b.Id
                                          join s in db.studentt on br.StudentId equals s.Id
                                          select new BorrowBookModel 
                                          {
                                              Id=br.Id,
                                              BookName = b.Name,
                                              StudentId=s.Id,
                                              StudentName = s.Name,
                                              ReturnDate = (DateTime)br.ReturnDate,
                                              BorrowDate = (DateTime)br.BorrowDate,
                                              PenaltyAmount = (decimal)(br.PenaltyAmount ?? 0)
                                          }).ToList();
            return listResult;    
        }
        public BorrowBookModel GetByPrimaryKey(int Id)
        {
            var borrowedBook = db.BorrowedBook.FirstOrDefault(f => f.Id == Id);
            if (borrowedBook != null)
            {
                var borrowBookModel = new BorrowBookModel
                {
                    Id = borrowedBook.Id,
                };
                return borrowBookModel;
            }
            else
            {
                return null;
            }
        }
            public void Insert(BorrowBookModel model)
            {
            var bookId = db.Book.Where(x => x.Name.Contains(model.BookName)).Select(x => x.Id).FirstOrDefault();
            var studID = db.studentt.Where(x => x.Name.Contains(model.StudentName)).Select(x => x.Id).FirstOrDefault();
            var newBorrowBook = new BorrowedBook
            {
                BookId = bookId,
                StudentId = studID,
                BorrowDate = model.BorrowDate,
                ReturnDate = model.ReturnDate,
                IsBorrowed = false,
                IsDeleted = false
            };
            db.BorrowedBook.Add(newBorrowBook);
            db.SaveChanges();
            if (model.ReturnDate < DateTime.Now)
            {
                model.PenaltyAmount = CalculatePenalty(model.ReturnDate);
            }
            else
            {
                model.PenaltyAmount = 0;
            }
            db.SaveChanges();
            
        }
        public void Update(BorrowBookModel update)
        {
            var editdata = db.BorrowedBook.FirstOrDefault(w => w.Id == update.Id);
            var bookId = db.Book.Where(x => x.Name.Contains(update.BookName)).Select(x => x.Id).FirstOrDefault();
            var studID = db.studentt.Where(x => x.Name.Contains(update.StudentName)).Select(x => x.Id).FirstOrDefault();
            if (editdata != null)
            {
                editdata.BookId = bookId;
                editdata.StudentId = studID;
                editdata.BorrowDate = update.BorrowDate;
                editdata.ReturnDate = update.ReturnDate;
                if (editdata.ReturnDate.HasValue && editdata.ReturnDate.Value < DateTime.Now)
                {
                    editdata.PenaltyAmount = CalculatePenalty(editdata.ReturnDate.Value);
                }
                else
                {
                    editdata.PenaltyAmount = 0;
                }
                db.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            var deleteData = db.BorrowedBook.FirstOrDefault(w => w.Id == Id);
            if (deleteData != null)
            {
                db.BorrowedBook.Remove(deleteData);
                db.SaveChanges();
            }
        }
        public IEnumerable<BorrowedBook> GetBorrowedBooksByStudentId(int studentId)
        { 
            return db.BorrowedBook.Where(w => w.StudentId == studentId && w.IsDeleted == false);
        }
        public decimal CalculatePenalty(DateTime returnDate)
        {
            int DatePeriod = 5;
            decimal penaltyPerDay = 20;
            TimeSpan overtimeDuration = DateTime.Now.Date - returnDate.Date;
            int daysOverdue = overtimeDuration.Days;
            if (daysOverdue <= 0)
            {
                return 0;
            }
            else if (daysOverdue <= DatePeriod)
            {
                return 0;
            }
            else
            {
                int extraDays = daysOverdue - DatePeriod;
                return extraDays * penaltyPerDay;
            }
        }
        
    }
}
