using SocialMedia.Infrastructure.Data;

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
