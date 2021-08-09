using SocialMedia.Core.Customs.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Core.Customs
{
    public class PagedList<T> : List<T>, IPagedList
    {
        #region Data
        public int Currentpage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
        #endregion

        #region Computed
        public bool HasPreviousPage => Currentpage > 1;
        public bool HasNextPage => Currentpage < TotalPages;
        public int? NextPageNumber => HasNextPage ? Currentpage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? Currentpage - 1 : (int?)null;
        #endregion

        #region Constructor
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalRows = count; // We could take it from items.Count()
            PageSize = pageSize;
            Currentpage = pageNumber;
            TotalPages = (int)Math.Ceiling(TotalRows / (double)PageSize); // The tutorial said "pageNumber" instead "pageSize"
            AddRange(items);
        }
        #endregion

        public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
