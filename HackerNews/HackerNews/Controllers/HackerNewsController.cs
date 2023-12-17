using HackerNews.Dtos;
using HackerNews.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HackerNews.Controllers
{
    [ApiController]
    [Route("hacker-news")]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;

        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("best-stories")]
        public async Task<List<StoryDetailsDto>> GetAsync([Range(1, int.MaxValue)][FromQuery] int count)
        {
            return await _hackerNewsService.GetBestStoriesAsync(count);
        }
    }
}