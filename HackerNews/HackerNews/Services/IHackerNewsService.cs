using HackerNews.Dtos;

namespace HackerNews.Services
{
    public interface IHackerNewsService
    {
        /// <summary>
        /// Gets first count of stories items
        /// </summary>
        /// <param name="count">Number of stories</param>
        /// <returns>List of StoryDetailsDto</returns>
        public Task<List<StoryDetailsDto>> GetBestStoriesAsync(int count);
    }
}
