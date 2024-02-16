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
    public class UnitTest_PageController : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UnitTest_PageController(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllPages_ReturnsOk()
        {
            var client = _factory.CreateClient();
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/page/2"); //pages from story with index 2

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetPage_ReturnsOk()
        {
            var client = _factory.CreateClient();
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/page/2/4"); //page with index 4 from story with index 2

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task PostAndGetPage_ReturnsOk()
        {
            var client = _factory.CreateClient();

            var page = new Page
            {
                PageTitle = "TestPage",
                PageText = "This is a test page",
                StoryId = 2,
            };

            //Act
            //Create page
            var response = await client.PostAsJsonAsync("/page", page);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        [Fact]
        public async Task CreateAndDeletePage_ReturnsNoContent()
        {
            var client = _factory.CreateClient();

            var page = new Page
            {
                PageTitle = "TestDeletePage",
                PageText = "This is a test page made to be deleted",
                StoryId = 2,
            };

            //Act
            //Create page
            var response = await client.PostAsJsonAsync("/page", page);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Retrieve the ID from the response body
            var createdPage = await response.Content.ReadFromJsonAsync<Collection>();
            var pageId = createdPage?.Id;

            //Delete page
            var response2 = await client.DeleteAsync($"/page/{pageId}");
            response2.EnsureSuccessStatusCode();
            response2.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
