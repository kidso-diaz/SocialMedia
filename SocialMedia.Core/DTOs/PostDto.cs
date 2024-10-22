﻿using System;

namespace SocialMedia.Core.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime PostDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
