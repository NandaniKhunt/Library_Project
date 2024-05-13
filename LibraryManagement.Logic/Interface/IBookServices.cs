using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManagement.Models.Custom;
using LibraryManagement.Models.Database;
namespace LibraryManagement.Logic.Interface
{
    public interface IBookServices
    {
       void Insert(Book Book);
        Book GetByPrimaryKey(int Id);
       void Update(Book update);

        void Delete(int Id);
      
        IEnumerable<Book> GetAllBook();
        IEnumerable<Book> GetOutOfStockBooks();

    }
}
