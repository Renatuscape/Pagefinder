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
    public class UserControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UserControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task GetAllUsers_ReturnsOk()
        {
            var client = _factory.CreateClient();
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/user");

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task PostAndGetUser_ReturnsOk()
        {
            var client = _factory.CreateClient();

            var user = new User
            {
                Username = "TestUser",
                Email = "email@test.com",
                Password = "test123",
            };

            //Act
            //Create user
            var response = await client.PostAsJsonAsync("/user", user);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        [Fact]
        public async Task CreateAndDeleteUser_ReturnsNoContent()
        {
            var client = _factory.CreateClient();

            var user = new User
            {
                Username = "TestDeleteUser",
                Email = "email@test.com",
                Password = "test123",
            };
            var createResponse = await client.PostAsJsonAsync("/user", user);

            createResponse.EnsureSuccessStatusCode();

            var jsonString = await createResponse.Content.ReadAsStringAsync();
            var newUser = JsonSerializer.Deserialize<User>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (newUser == null)
            {
                throw new Exception("User not created");
            }

            var userId = newUser.Id;

            //Act
            var deleteResponse = await client.DeleteAsync($"/user/{userId}");

            deleteResponse.EnsureSuccessStatusCode();
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        }
    }
}