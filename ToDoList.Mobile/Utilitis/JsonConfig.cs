using System.Text.Json;

namespace ToDoList.Mobile.Utilitis;

public static class JsonConfig
{
    public static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };
}