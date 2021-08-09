﻿using SocialMedia.Core.Entities;
using SocialMedia.Core.Entities.Base;
using SocialMedia.Core.Entities.Customs;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IPagedList<Post> GetPosts(PostQueryFilter filters)
        {
            var posts = _unitOfWork.PostRepository.GetAll();

            /// Query Filter
            if (filters.UserId != null) posts = posts.Where(x => x.UserId == filters.UserId);
            if (filters.PostDate != null) posts = posts.Where(x => x.PostDate == filters.PostDate);
            if (filters.Description != null) posts = posts.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));

            /// Pagination Filter
            var pagedPosts = PagedList<Post>.Create(posts, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task InsertPost(Post post)
        {
            /// Validación existencia Usuario
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null) throw new BusinessException("User doesn't exist");
            
            /// Validación 
            var userPost = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if (userPost != null && userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x => x.PostDate).FirstOrDefault(); // Obtenemos el último post
                if ((DateTime.Now - lastPost.PostDate).TotalDays < 7)
                {
                    throw new BusinessException("You are not able to post now");
                }
            }

            if (post.Description.ToLower().Contains("sexo")) throw new BusinessException("Content not allowed");
            
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
            return true; // provisional
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true; // provisional
        }
    }
}