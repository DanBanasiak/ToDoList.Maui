using System.Text.Json;
using ToDoList.Mobile.Models;
using ToDoList.Mobile.Utilitis;

namespace ToDoList.Mobile.Services;

public interface IItemsService
{
    Task<List<GetIssueDto>> GetItemsAsync();
    //Task<Item> GetItemAsync(int id);
    //Task<Item> AddItemAsync(Item item);
    //Task<Item> UpdateItemAsync(Item item);
    //Task DeleteItemAsync(int id);

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
        try
        {
            var dtos = JsonSerializer.Deserialize<List<GetIssueDto>>(response, JsonConfig.Options);
            return dtos;

        }
        catch (Exception ex)
        {
            var temp = ex;
        }
        return null;
    }
}