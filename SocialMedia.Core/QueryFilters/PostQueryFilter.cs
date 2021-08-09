using SocialMedia.Core.QueryFilters.Base;
using System;

namespace SocialMedia.Core.QueryFilters
{
    public class PostQueryFilter : FilterBase
    {
        public int? UserId { get; set; }
        public DateTime? PostDate { get; set; }
        public string Description { get; set; }
    }
}
