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
    public class UnitTest_CollectionController : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UnitTest_CollectionController(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;

        }

        [Fact]
        public async Task GetAllCollections_ReturnsOk()
        {
            var client = _factory.CreateClient();
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/collection");

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PostAndGetCollection_ReturnsCreated()
        {
            var client = _factory.CreateClient();

            var collection = new Collection
            {
                Name = "TestCollection",
                Description = "This collection is for testing purposes.",
                UserId = 4 // User must exist with this ID for test to succeed
            };

            //Act
            //Create collection
            var response = await client.PostAsJsonAsync("/collection", collection);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        [Fact]
        public async Task CreateAndDeleteCollection_ReturnsNoContent()
        {
            var client = _factory.CreateClient();

            var collection = new Collection
            {
                Name = "TestDeleteCollection",
                Description = "This collection is born only to die.",
                UserId = 4 // User must exist with this ID for test to succeed
            };

            // Act - Create collection
            var response = await client.PostAsJsonAsync("/collection", collection);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Retrieve the ID from the response body
            var createdCollection = await response.Content.ReadFromJsonAsync<Collection>();
            var collectionId = createdCollection?.Id;

            // Delete collection using the retrieved ID
            var response2 = await client.DeleteAsync($"/collection/{collectionId}");
            response2.EnsureSuccessStatusCode();
            response2.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
