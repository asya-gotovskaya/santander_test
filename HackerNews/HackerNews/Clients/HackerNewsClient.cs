using HackerNews.Dtos;
using HackerNews.Exceptions;
using System.Text.Json;

namespace HackerNews.Clients
{
    public class HackerNewsClient : IHackerNewsClient
    {
        private const string STORY_IDS_ENDPOINT = "beststories.json";
        private const string STORY_ITEM_ENDPOINT = "item/{0}.json";

        private readonly HttpClient _client;

        public HackerNewsClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<int>> GetStoryIdsAsync()
        {
            using HttpResponseMessage response = await _client.GetAsync(STORY_IDS_ENDPOINT);

            CheckIsSuccessfullStatusCode(response);

            string data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<int>>(data)!;
        }

        public async Task<StoryItemDto> GetStoryItemAsync(int id)
        {
            using HttpResponseMessage storyItemResponse = await _client.GetAsync(string.Format(STORY_ITEM_ENDPOINT, id));

            CheckIsSuccessfullStatusCode(storyItemResponse);

            string data = await storyItemResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StoryItemDto>(data)!;
        }

        private void CheckIsSuccessfullStatusCode(HttpResponseMessage response) 
        {
			if (!response.IsSuccessStatusCode) 
            {
                throw new HackerNewsException($"Hacker News response status is: {response.StatusCode}");
            }
        }
    }
}
