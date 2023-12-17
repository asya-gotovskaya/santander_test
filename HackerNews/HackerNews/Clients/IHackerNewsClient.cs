using HackerNews.Dtos;

namespace HackerNews.Clients
{
    public interface IHackerNewsClient
    {
        Task<List<int>> GetStoryIdsAsync();

        Task<StoryItemDto> GetStoryItemAsync(int id);
    }
}
