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

         TryAsync<Post> GetPostById(int id);
         
         TryAsync<Post> AddPost(Post newPost);

         TryAsync<Post> UpdatePost(Post newPost);

         TryAsync<int> DeletePost(int postId);
    }
}