using SocialMedia.Core.QueryFilters.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.QueryFilters
{
    public class PostQueryFilter : FilterBase
    {
        public int? UserId { get; set; }
        public DateTime? PostDate { get; set; }
        public string Description { get; set; }
    }
}
