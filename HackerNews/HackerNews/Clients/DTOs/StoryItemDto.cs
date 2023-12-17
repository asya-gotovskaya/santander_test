using HackerNews.Converters;
using System.Text.Json.Serialization;

namespace HackerNews.Dtos
{
    public class StoryItemDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("by")]
        public string By { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("time")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime Time { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("descendants")]
        public int Descendants { get; set; }
    }
}
