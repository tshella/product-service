using ProductApi.Models;
using System.Text.Json;

namespace ProductApi.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.restful-api.dev/objects";

    public ProductService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<IEnumerable<JsonElement>> GetFilteredProductsAsync(string? name, int page, int pageSize)
    {
        var response = await _httpClient.GetAsync(BaseUrl);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<List<JsonElement>>();
        var filtered = content!
            .Where(p => string.IsNullOrEmpty(name) || p.GetProperty("name").GetString()?.Contains(name, StringComparison.OrdinalIgnoreCase) == true)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return filtered;
    }

    public async Task<JsonElement> GetProductByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<JsonElement>();
    }

    public async Task<JsonElement> AddProductAsync(ProductDto dto)
    {
        var payload = new { name = dto.Name, data = new { description = dto.Description, price = dto.Price } };
        var response = await _httpClient.PostAsJsonAsync(BaseUrl, payload);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<JsonElement>();
    }

    public async Task<JsonElement> UpdateProductAsync(string id, ProductDto dto)
    {
        var payload = new { name = dto.Name, data = new { description = dto.Description, price = dto.Price } };
        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", payload);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<JsonElement>();
    }

    public async Task DeleteProductAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
