using LibraryManagement.Models;
using LibraryManagement.Logic.Interface;
using LibraryManagement.Models.Database;
using LibraryManagement.Core.Paging;
using LibraryManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace LibraryManagement.Logic.Implementation
{
    public class BookServices : BaseServices,IBookServices
    {
        public IEnumerable<Book> GetAllBook()
        {
             return db.Book.Where(w => w.IsDeleted == false);
        }
        public Book GetByPrimaryKey(int Id)
        {
            return db.Book.FirstOrDefault(f => f.Id == Id);
        }
        public void Insert(Book bookModel)
        {
            var newBook = new Book
            {
                Name = bookModel.Name,
                Information = bookModel.Information,
                Quantity = bookModel.Quantity,
                AuthorName = bookModel.Author.Name,
                IsDeleted = false
            };
            var existingAuthor = db.Author.FirstOrDefault(a => a.Name == bookModel.Author.Name);
            if (existingAuthor == null)
            {
                var newAuthor = new Author
                {
                    Name = bookModel.Author.Name
                };
                newBook.Author = newAuthor;
            }
            else
            {
                newBook.AuthorId = existingAuthor.Id;
            }
            db.Book.Add(newBook);
            db.SaveChanges();
            NotifyStudentsAboutAvailableBook(bookModel.Name, bookModel.studentt.Id);     
        }
        private void NotifyStudentsAboutAvailableBook(string bookName, int studentId)
        {
            var pendingRequests = db.BorrowedBook.Where(b => b.Book.Name == bookName && b.StudentId == studentId).ToList();
            if (pendingRequests.Any())
            {
                foreach (var request in pendingRequests)
                {
                    SendEmailToStudent(request.studentt.Id, bookName);
                }
            }
        }
        private void SendEmailToStudent(int studentId, string bookName)
        {
            var student = db.studentt.FirstOrDefault(s => s.Id == studentId);
            var email = student.Email;
            var mail = new MailMessage();
            mail.From = new MailAddress("khuntnandini@gmail.com", "VENTURE LIBRARY");
            mail.To.Add(email);
            mail.Subject = "Book Availability Notification";
            mail.Body = $"Dear {student.Name},The Book '{bookName}' You Requested is now available in the library";
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                try
                {
                    smtpClient.Send(mail);
                    Console.WriteLine("Email Successfully Sent..");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to send email. Error: " + ex.Message);
                }
            }
        }
        public void Update(Book update)
        {
           var editdata= db.Book.FirstOrDefault(w => w.Id == update.Id);
            if (editdata != null)
            {
                editdata.Name = update.Name;
                editdata.Information = update.Information;
                editdata.Author.Name = update.Author.Name;
                editdata.Quantity = update.Quantity;
                db.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            var deleteData = db.Book.FirstOrDefault(w => w.Id == Id);
            if (deleteData != null)
            {
                db.Book.Remove(deleteData); 
                db.SaveChanges();
            }
        }
        public IEnumerable<Book> GetOutOfStockBooks()
        {
            return db.Book.Where(b => b.Stock <= 0)
                          .Select(b => new Book
                          {
                              Name = b.Name,
                              Information = b.Information,
                              Quantity = b.Quantity,
                              AuthorName = b.Author.Name,
                              Stock = b.Stock 
                          });
        }
    }
}

