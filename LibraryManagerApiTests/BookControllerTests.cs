using System.Text;
using Newtonsoft.Json;
using Domain.Models;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

public class BooksControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public BooksControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllBooks_ReturnsOkResponse()
    {
        // Arrange
        await EnsureBookCreatedAsync(new Book { Title = "Initial Book", Description = "Description", AuthorId = 1, BookGenreId = 1 });
        var request = new HttpRequestMessage(HttpMethod.Get, "book");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<List<Book>>(responseString);
        Assert.NotNull(books);
        Assert.NotEmpty(books);
    }



    [Fact]
    public async Task CreateBook_NullBook_ReturnsBadRequest()
    {
        // Arrange
        Book book = null;
        var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("book", content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateBook_NullBook_ReturnsBadRequest()
    {
        // Arrange
        Book book = null;
        var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync("book", content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    private async Task EnsureBookCreatedAsync(Book book)
    {
        var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/book", content);
        response.EnsureSuccessStatusCode();
    }
}
