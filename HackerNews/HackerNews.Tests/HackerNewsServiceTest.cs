using HackerNews.Clients;
using HackerNews.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;

namespace HackerNews.Tests
{
	public class Tests
	{
		[Test]
		public async Task GetBestStoriesAsync_NumberOfBestStories_ReturnsBestStories()
		{
			// Arrange
			var hackerNewsClientMock = new Mock<IHackerNewsClient>();
			hackerNewsClientMock.Setup(client => client.GetStoryIdsAsync())
				.ReturnsAsync(new List<int>() { 1, 2, 3 });
			hackerNewsClientMock.Setup(client => client.GetStoryItemAsync(It.IsAny<int>()))
				.ReturnsAsync(new Dtos.StoryItemDto());

			var hackerNewsService = new HackerNewsService(
				hackerNewsClientMock.Object, new MemoryCache(new MemoryCacheOptions()));

			// Act
			var result = await hackerNewsService.GetBestStoriesAsync(3);

			// Assert
			Assert.AreEqual(3, result.Count);
		}
	}
}