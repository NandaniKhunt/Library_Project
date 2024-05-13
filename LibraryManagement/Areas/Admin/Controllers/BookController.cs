using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using System.Web.Mvc;
using LibraryManagement.Logic.Implementation;
using LibraryManagement.Logic.Interface;
using LibraryManagement.Models.Database;
using PagedList;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [RoutePrefix("Admin")]
    public class BookController : Controller
    {
        private const int PageSize = 5;
        IBookServices BookServices = new BookServices();
        // GET: Admin/Book
        [Route("Book")]
        public ActionResult Index(int page = 1)
        {
            var books = BookServices.GetAllBook().ToList();
            var pagedBooks = books.ToPagedList(page, PageSize);
            return View(pagedBooks);
            
        }
        [Route("Book/Add")]
        public ActionResult Add()
        {
            return View();
        }
        [Route("Book/Add")]
        [HttpPost]
        public ActionResult Add(Book model)
        {
            var book = new Book
            {
                Name = model.Name,
                Information = model.Information,
                Quantity = model.Quantity,
                Author = new Author { Name = model.Author.Name } 
            };
            BookServices.Insert(book);
            this.ShowMessage(MessageExtension.MessageType.Success, "Record successfully saved", true);
            return RedirectToAction("Index");
        }
        [Route("Book/Edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            var _model = BookServices.GetByPrimaryKey(Id);
            return View(_model);
        }
        [HttpPost]
        [Route("Book/Edit/{Id}")]
        public ActionResult Edit(Book model)
        {
            BookServices.Update(model);
            this.ShowMessage(MessageExtension.MessageType.Success, "Successfully updated", true);
            return RedirectToAction("Index");
        }
        [Route("Book/Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            BookServices.Delete(Id);
            this.ShowMessage(MessageExtension.MessageType.Success, "Successfully deleted", true);
            return RedirectToAction("Index");
        }
        [Route("Book/OutOfStock")]
        public ActionResult OutOfStock()
        {
            var outOfStockBooks = BookServices.GetOutOfStockBooks().ToList();
            return View(outOfStockBooks);
        }
    }
}