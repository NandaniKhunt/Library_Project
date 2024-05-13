using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Linq.Dynamic;

namespace LibraryManagement.Core.Paging
{ 
    public class PagerList<T>
    {
        public int PageRows { get; private set; }
        public IEnumerable<T> PageList { get; private set; }
        public int PageNumber { get; private set; }
        public int TotalRows { get; private set; }
        public int TotalPage { get; private set; }
        public string SortBy { get; private set; }
        public PagerList(IEnumerable<T> pageList, int pageNumber, int pageRows, int totalRows, string sortBy = "")
        {
            PageRows = pageRows;
            TotalRows = totalRows;
            PageList = pageList;
            PageNumber = pageNumber;
            SortBy = sortBy;
            TotalPage = ConvertTo.Rounds(ConvertTo.Decimal(totalRows / PageRows));
        }
    }











    //public static class PagerQueryExtension
    //{
    //    public static PagerList<T> ToPagerListOrderBy<T>(this IQueryable<T> query, int PageNumber, int PageRows, string orderBy)
    //    {
    //        if (PageNumber < 1)
    //            PageNumber = 1;
    //        var itemsToSkip = (PageNumber - 1) * PageRows;
    //        var totalRows = query.Count();
    //        var pagerList = query.OrderBy(orderBy).Skip(itemsToSkip).Take(PageRows).AsEnumerable();
    //        return new PagerList<T>(pagerList, PageNumber, PageRows, totalRows, orderBy);
    //    }
    }

