using System.Text.Json;
using ToDoList.Mobile.Models;

//using ToDoList.Mobile.Models;
using ToDoList.Mobile.Utilitis;

namespace ToDoList.Mobile.Services;

public interface IItemsService
{
    Task<List<GetIssueDto>> GetItemsAsync();
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

    public async Task<List<GetIssueDto>> GetItemsAsync()
    {
        var request = await _httpClient.GetAsync("Items");
        var response = await request.Content.ReadAsStringAsync();
        var dtos = JsonSerializer.Deserialize<List<GetIssueDto>>(response, JsonConfig.Options);
        return dtos;
    }
}