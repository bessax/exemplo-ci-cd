using Microsoft.AspNetCore.Mvc.Testing;

namespace my_app_exemplo_ci_tests;
public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetRoot_DeveRetornar200()
    {
        var response = await _client.GetAsync("/");
        response.EnsureSuccessStatusCode();
    }
}