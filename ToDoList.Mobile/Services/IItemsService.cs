using System.Text;
using System.Text.Json;
using ToDoList.Mobile.Models;
using ToDoList.Mobile.Utilitis;

namespace ToDoList.Mobile.Services;

public interface IItemsService
{
    Task<List<GetIssueDto>> GetItemsAsync();
    Task<Guid> CreateItemAsync(CreateIssueDto dto);
    Task<Guid> CompleteItemAsync(Guid id);
    Task<List<GetIssueDto>> GetItemsHistoryAsync();
}

public class ItemsService : IItemsService
{
    private readonly HttpClient _httpClient;
    public ItemsService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://bookdance-dev-app.azurewebsites.net/")
        };
    }

    public async Task<List<GetIssueDto>> GetItemsHistoryAsync()
    {
        var request = await _httpClient.GetAsync("Items/History");
        var response = await request.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<GetIssueDto>>(response, JsonConfig.Options);
    }
    public async Task<Guid> CompleteItemAsync(Guid id)
    {
        await _httpClient.PutAsync($"Items/{id}/complete", null);
        return id;
    }

    public async Task<Guid> CreateItemAsync(CreateIssueDto dto)
    {
        var json = JsonSerializer.Serialize(dto, JsonConfig.Options);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var result = await _httpClient.PostAsync("Items", content);
        if (result.IsSuccessStatusCode)
        {
            var response = await result.Content.ReadAsStringAsync();
            var id = JsonSerializer.Deserialize<Guid>(response, JsonConfig.Options);
            return id;
        }
        else
        {
            throw new Exception("Something went wrong");
        }
    }

    public async Task<List<GetIssueDto>> GetItemsAsync()
    {
        var request = await _httpClient.GetAsync("Items");
        var response = await request.Content.ReadAsStringAsync();
        var dtos = JsonSerializer.Deserialize<List<GetIssueDto>>(response, JsonConfig.Options);
        return dtos;
    }

}