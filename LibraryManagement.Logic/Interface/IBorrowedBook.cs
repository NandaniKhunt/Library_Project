using LibraryManagement.Models.Database;
using System;
using LibraryManagement.Models.Custom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Logic.Interface
{
    public interface IBorrowedBook
    {
        List<BorrowBookModel> GetBorrowedBook();

        void Insert(BorrowBookModel model);

        BorrowBookModel GetByPrimaryKey(int Id);

        void Update(BorrowBookModel update);

        void Delete(int Id);

        IEnumerable<BorrowedBook> GetBorrowedBooksByStudentId(int studentId);
        
       
    }
}
