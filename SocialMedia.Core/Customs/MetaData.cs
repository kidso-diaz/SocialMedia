using SocialMedia.Core.Customs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.Customs
{
    public class MetaData : IPagedList
    {
        public int Currentpage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }

        public bool HasPreviousPage => Currentpage > 1;
        public bool HasNextPage => Currentpage < TotalPages;
        public int? NextPageNumber => HasNextPage ? Currentpage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? Currentpage - 1 : (int?)null;
    }
}
