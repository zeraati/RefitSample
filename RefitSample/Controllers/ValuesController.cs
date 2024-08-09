using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace RefitSample.Controllers;
[Route("api/[controller]"), ApiController]
public class ValuesController : ControllerBase
{
    private readonly HttpClient _httpClient;
    public ValuesController(HttpClient httpClient)=> _httpClient = httpClient;

    [HttpGet("{UserId}")]
    public async Task<IActionResult> Get(int UserId)
    {
        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.GetAsync($"/todos/{UserId}");
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        return Ok(responseBody);
    }
}
