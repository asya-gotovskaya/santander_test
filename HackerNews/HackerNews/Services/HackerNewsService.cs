using HackerNews.Clients;
using HackerNews.Dtos;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNews.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private const int EXPIRATION_TIME = 60;

        private readonly IHackerNewsClient _client;
        private readonly IMemoryCache _memoryCache;

        public HackerNewsService(IHackerNewsClient client, IMemoryCache memoryCache)
        {
            _client = client;
            _memoryCache = memoryCache;
        }

        public async Task<List<StoryDetailsDto>> GetBestStoriesAsync(int count)
        {
            List<int> ids = await GetStoryItemsIdsAsync(count);

            var stories = new List<StoryDetailsDto>();

            foreach (var id in ids)
            {
                StoryItemDto story = await GetStoryItemAsync(id);
                stories.Add(MapStoryItemToBestStory(story));
            }

            return stories;
        }

        private async Task<List<int>> GetStoryItemsIdsAsync(int n)
        {
            List<int> storyIds = await _client.GetStoryIdsAsync();
            return storyIds.Take(n).ToList();
        }

        private async Task<StoryItemDto> GetStoryItemAsync(int id)
        {
            return await _memoryCache.GetOrCreateAsync(id, cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(EXPIRATION_TIME);
                return _client.GetStoryItemAsync(id);
            });
        }

        private StoryDetailsDto MapStoryItemToBestStory(StoryItemDto storyItem)
        {
            return new StoryDetailsDto()
            {
                PostedBy = storyItem.By,
                Score = storyItem.Score,
                Time = storyItem.Time,
                Title = storyItem.Title,
                Uri = storyItem.Url,
                CommentCount = storyItem.Descendants
            };
        }
    }
}
