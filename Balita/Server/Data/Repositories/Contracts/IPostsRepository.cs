using System;
using System.Collections.Generic;
using Balita.Data.Models;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Balita.Server.Data.Repositories.Contracts
{
    public interface IPostsRepository
    {
         TryAsync<List<Post>> GetAllPosts();

         TryAsync<List<Post>> GetAllPosts(DateTime startDate, DateTime endDate);

         TryAsync<List<Post>> GetPostsByCategory(int categoryId);

         TryAsync<List<Post>> GetPostsByCategory(int categoryId, int count);

         TryAsync<List<Post>> GetPostsByCategory(Option<int> categoryId, Option<int> count);

         TryOptionAsync<Post> GetPostById(int id);
         
         TryOptionAsync<Post> AddPost(Post newPost);

         TryOptionAsync<Post> UpdatePost(Post newPost);

         TryOptionAsync<int> DeletePost(int postId);
    }
}