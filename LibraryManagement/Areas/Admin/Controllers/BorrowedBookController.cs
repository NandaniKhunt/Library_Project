using LibraryManagement.Logic.Implementation;
using LibraryManagement.Logic.Interface;
using LibraryManagement.Models;
using LibraryManagement.Models.Database;
using LibraryManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [RoutePrefix("Admin")]
    public class BorrowedBookController : Controller
    {
        private const int PageSize = 5;
        IBorrowedBook BorrowedBookServices = new BorrowedBookServices();
        LibraryManagementContext db = new LibraryManagementContext();
        // GET: Admin/BorrowedBook
        [Route("BorrowedBook")]
        public ActionResult Index(int page = 1)
        {
            var Borrowedbooks = BorrowedBookServices.GetBorrowedBook().ToList();
            var pagedBooks = Borrowedbooks.ToPagedList(page, PageSize);
            return View(pagedBooks);
        }
        [Route("BorrowedBook/Add")]
        public ActionResult Add()
        {
           
            ViewBag.BookList = BorrowedBookServices.GetBorrowedBook();
            return View();
        }
        [Route("BorrowedBook/Add")]
        [HttpPost]
        public ActionResult Add(BorrowBookModel model)
        {
            var existingBook = db.Book.FirstOrDefault(a => a.Name == model.BookName);
            if (existingBook != null && existingBook.Quantity > 0)
            {
                db.SaveChanges();
            }
            else
            {
                return Content("<script>alert('Book is not available for borrowing.');</script>");
            }
            BorrowedBookServices.Insert(model);
            this.ShowMessage(MessageExtension.MessageType.Success, "Successfully Inserted", true);
            return RedirectToAction("Index");
        }
        [Route("BorrowedBook/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            var model = BorrowedBookServices.GetByPrimaryKey(Id);
            return View(model);
        }
        [HttpPost]
        [Route("BorrowedBook/Edit/{Id}")]
        public ActionResult Edit(BorrowBookModel model)
        {
            BorrowedBookServices.Update(model);
            this.ShowMessage(MessageExtension.MessageType.Success, "Successfully updated", true);
            return RedirectToAction("Index");
        }
        [Route("BorrowedBook/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            BorrowedBookServices.Delete(Id);
            this.ShowMessage(MessageExtension.MessageType.Success, "Successfully deleted", true);
            return RedirectToAction("Index");
        }
    }
}