using LibraryManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Custom
{
   public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public bool IsDeleted { get; set; }
        public Author Author { get; set; }
    }
}
