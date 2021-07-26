using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private readonly IRepository<Post> _postRepository = null;
        private readonly IRepository<User> _userRepository = null;
        private readonly IRepository<Comment> _commentRepository = null;

        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }

        public IRepository<Post> PostRepository => _postRepository ?? new RepositoryBase<Post>(_context);

        public IRepository<User> UserRepository => _userRepository ?? new RepositoryBase<User>(_context);

        public IRepository<Comment> CommentRepository => _commentRepository ?? new RepositoryBase<Comment>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
