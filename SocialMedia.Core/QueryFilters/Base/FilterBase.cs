using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.QueryFilters.Base
{
    public abstract class FilterBase
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
