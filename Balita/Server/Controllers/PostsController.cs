using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Balita.Server.Data.Repositories.Contracts;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LanguageExt.Prelude;


namespace Balita.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepository _postsRepository;

        public PostsController(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => await _postsRepository.GetAllPosts()
               .Match(
                   Succ: x => Ok(x), 
                   Fail: x => StatusCode(500, x));


        [HttpGet("/{start}/{end}/")]
        public async Task<IActionResult> GetByDate(DateTime start, DateTime end)
            => await _postsRepository.GetAllPosts(start, end)
                .Match(Succ: x => Ok(x),
                       Fail: x => StatusCode(500, x));

        [HttpGet("/bycat/{categoryId}/{count}")]
        public async Task<IActionResult> GetByCategory(int categoryId, int count)
            => await _postsRepository.GetPostsByCategory(categoryId, count)
                .Match(Succ: x => Ok(x),
                    Fail: x => StatusCode(500, x));


        public async Task<IActionResult> GetCategories(Option<int> categoryId, Option<int> count)
            => await _postsRepository.GetPostsByCategory(categoryId, count)
                .Match(Succ: x => Ok(x),
                    Fail: x => StatusCode(500, x));

    }
}
