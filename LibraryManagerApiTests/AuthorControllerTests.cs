using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;
using Infrastructure.Data;
using Domain.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;

public class AuthorsControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public AuthorsControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllAuthors_ReturnsOkResponse()
    {
        // Arrange
        await EnsureAuthorCreatedAsync(new Author { Name = "Initial Author" });
        var request = new HttpRequestMessage(HttpMethod.Get, "author");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var authors = JsonConvert.DeserializeObject<List<Author>>(responseString);
        Assert.NotNull(authors);
        Assert.NotEmpty(authors); 
    }

    [Fact]
    public async Task CreateAuthor_ReturnsCreatedResponse()
    {
        // Arrange
        var author = new Author { Name = "New Author" };
        var content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("author", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

        // Verify
        var responseString = await response.Content.ReadAsStringAsync();
        var createdAuthor = JsonConvert.DeserializeObject<Author>(responseString);
        Assert.NotNull(createdAuthor);
        Assert.Equal("New Author", createdAuthor.Name);
    }

    [Fact]
    public async Task CreateAuthor_DuplicateName_ReturnsConflictResponse()
    {
        // Arrange
        var author = new Author { Name = "Duplicate Author" };
        await EnsureAuthorCreatedAsync(author);
        var duplicateAuthorContent = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("author", duplicateAuthorContent);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.Conflict, response.StatusCode);
    }

    [Fact]
    public async Task CreateAuthor_NullAuthor_ReturnsBadRequest()
    {
        // Arrange
        Author author = null;
        var content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("author", content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateAuthor_NullAuthor_ReturnsBadRequest()
    {
        // Arrange
        Author author = null;
        var content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync("author", content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    private async Task EnsureAuthorCreatedAsync(Author author)
    {
        var content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/author", content);
        response.EnsureSuccessStatusCode();
    }
}
