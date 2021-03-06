﻿using Balita.Data.Models;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Balita.Data;
using Balita.Server.Data.Repositories.Contracts;
using static LanguageExt.Prelude;

namespace Balita.Server.Data.Repositories.Implementations
{
    public class PostsRepository : IPostsRepository
    {
        private readonly ApplicationDbContext _context;
        public PostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public TryAsync<List<Post>> GetAllPosts()
            => TryAsync(async () =>
                await _context.Posts
                    .OrderByDescending(x => x.PostedDate)
                    .AsNoTracking()
                    .ToListAsync());

        public TryAsync<List<Post>> GetAllPosts(DateTime startDate, DateTime endDate)
            => TryAsync(async () =>
                await _context.Posts
                    .Where(x => x.PostedDate >= startDate && x.PostedDate <= endDate)
                    .OrderByDescending(x => x.PostedDate)
                    .AsNoTracking()
                    .ToListAsync());

        public TryAsync<List<Post>> GetPostsByCategory(int categoryId)
            => TryAsync(async () =>
                await _context.Posts
                    .Where(x => x.CategoryId == categoryId)
                    .AsNoTracking()
                    .ToListAsync());

        public TryAsync<List<Post>> GetPostsByCategory(int categoryId, int count)
            => TryAsync(async () =>
                await _context.Posts
                    .Where(x => x.CategoryId == categoryId)
                    .Take(count)
                    .AsNoTracking()
                    .ToListAsync());

        public TryAsync<List<Post>> GetPostsByCategory(Option<int> categoryId, Option<int> count)
            => TryAsync(async () =>
                await _context.Posts.Where(x => Some(x.CategoryId) == categoryId)
                    .TakeOption(count)
                    .AsNoTracking()
                    .ToListAsync());

        public TryOptionAsync<Post> GetPostById(int id)
            => TryOptionAsync(async () =>
                await _context.Posts.
                    FirstOrDefaultAsync(x => x.Id == id));

        public TryOptionAsync<Post> AddPost(Post newPost)
            => TryOptionAsync(async () =>
            {
                await _context.Posts.AddAsync(newPost);
                await _context.SaveChangesAsync();
                return newPost;
            });

        public TryOptionAsync<Post> UpdatePost(Post newPost)
            => TryOptionAsync(async () =>
            {
                _context.Entry(newPost).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return newPost;
            });

        public TryOptionAsync<int> DeletePost(int postId)
            => TryOptionAsync(async () =>
            {
                var item = _context.Posts.FindAsync(postId);
                _context.Entry(item).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            });
    }
}