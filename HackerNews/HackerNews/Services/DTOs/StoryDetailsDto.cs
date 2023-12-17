using HackerNews.Converters;
using System.Text.Json.Serialization;

namespace HackerNews.Dtos
{
    public class StoryDetailsDto
    {
        [JsonPropertyName("postedBy")]
        public string PostedBy { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("commentCount")]
        public int CommentCount { get; set; }
    }
}
