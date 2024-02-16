using PagefinderDb;
using PagefinderDb.Data;
using PagefinderDb.Data.Models;
using System.Net.Http.Json;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace PagefinderUnitTesting
{
    public class UnitTest_StoryController : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UnitTest_StoryController(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;

        }

        [Fact]
        public async Task GetAllStories_ReturnsOk()
        {
            var client = _factory.CreateClient();
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/story");

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PostAndGetStory_ReturnsCreated()
        {
            var client = _factory.CreateClient();

            var story = new Story
            {
                Title = "TestStory",
                Description = "This story is for testing purposes.",
                CollectionId = 4 // Collection must exist with this ID for test to succeed
            };

            //Act
            //Create story
            var response = await client.PostAsJsonAsync("/story", story);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        [Fact]
        public async Task CreateAndDeleteStory_ReturnsNoContent()
        {
            var client = _factory.CreateClient();

            var story = new Story
            {
                Title = "TestStory",
                Description = "This story is for testing purposes.",
                CollectionId = 4 // Collection must exist with this ID for test to succeed
            };

            //Act
            //Create story
            var response = await client.PostAsJsonAsync("/story", story);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Retrieve the ID from the response body
            var createdStory = await response.Content.ReadFromJsonAsync<Collection>();
            var storyId = createdStory?.Id;

            //Delete story
            var deleteResponse = await client.DeleteAsync($"/story/{storyId}");

            deleteResponse.EnsureSuccessStatusCode();
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
