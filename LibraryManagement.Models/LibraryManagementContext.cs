using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibraryManagement.Models.Database;
using System.Data.Entity.Infrastructure;

namespace LibraryManagement.Models
{
    public partial class LibraryManagementContext : DbContext
    {
       
        public LibraryManagementContext()
            : base("name=BookDBEntities")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
       
        public DbSet<User> User { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<studentt> studentt { get; set; }

        public DbSet<BorrowBook> BorrowBook { get; set; }
        public DbSet<BorrowedBook> BorrowedBook { get; set; }
    }
}

