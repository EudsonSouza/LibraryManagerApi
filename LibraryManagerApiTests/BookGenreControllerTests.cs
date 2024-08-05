using System.Text;
using Newtonsoft.Json;
using Domain.Models;

public class BookGenresControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public BookGenresControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllBookGenres_ReturnsOkResponse()
    {
        // Arrange
        await EnsureBookGenreCreatedAsync(new BookGenre { Name = "Initial Genre" });
        var request = new HttpRequestMessage(HttpMethod.Get, "bookgenre");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var bookGenres = JsonConvert.DeserializeObject<List<BookGenre>>(responseString);
        Assert.NotNull(bookGenres);
        Assert.NotEmpty(bookGenres);
    }

    [Fact]
    public async Task CreateBookGenre_ReturnsCreatedResponse()
    {
        // Arrange
        var bookGenre = new BookGenre { Name = "New Genre" };
        var content = new StringContent(JsonConvert.SerializeObject(bookGenre), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("bookgenre", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

        // Verify
        var responseString = await response.Content.ReadAsStringAsync();
        var createdBookGenre = JsonConvert.DeserializeObject<BookGenre>(responseString);
        Assert.NotNull(createdBookGenre);
        Assert.Equal("New Genre", createdBookGenre.Name);
    }

    [Fact]
    public async Task CreateBookGenre_DuplicateName_ReturnsConflictResponse()
    {
        // Arrange
        var bookGenre = new BookGenre { Name = "Duplicate Genre" };
        await EnsureBookGenreCreatedAsync(bookGenre);
        var duplicateBookGenreContent = new StringContent(JsonConvert.SerializeObject(bookGenre), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("bookgenre", duplicateBookGenreContent);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.Conflict, response.StatusCode);
    }

    [Fact]
    public async Task CreateBookGenre_NullBookGenre_ReturnsBadRequest()
    {
        // Arrange
        BookGenre bookGenre = null;
        var content = new StringContent(JsonConvert.SerializeObject(bookGenre), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("bookgenre", content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateBookGenre_NullBookGenre_ReturnsBadRequest()
    {
        // Arrange
        BookGenre bookGenre = null;
        var content = new StringContent(JsonConvert.SerializeObject(bookGenre), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync("bookgenre", content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    private async Task EnsureBookGenreCreatedAsync(BookGenre bookGenre)
    {
        var content = new StringContent(JsonConvert.SerializeObject(bookGenre), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/bookgenre", content);
        response.EnsureSuccessStatusCode();
    }
}
