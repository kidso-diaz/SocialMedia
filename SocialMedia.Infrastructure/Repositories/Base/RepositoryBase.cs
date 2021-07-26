using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Repositories.Base
{
    public abstract class RepositoryBase
    {
        protected readonly SocialMediaContext _context;

        public RepositoryBase(SocialMediaContext context)
        {
            _context = context;
        }
    }
}
