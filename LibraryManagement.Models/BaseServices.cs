using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class BaseServices
    {
        private LibraryManagementContext _db;

        public LibraryManagementContext db
        {
            get => _db ?? (_db = new LibraryManagementContext());
            set { _db = value; }
        }

        public void Dispose()
        {
            var context = _db as IDisposable;
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
