using PetstoreApp.Models;
using System.Text.Json;

namespace PetstoreApp.Services;

public class MascotaServices: IMascotaServices
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    public MascotaServices(HttpClient client)
	{
        _client = client;
    }

    public async Task<List<Mascota>> GetByStatus(string status)
    {
        var response = await _client.GetAsync($"findByStatus/?status={status}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        var mascotas = System.Text.Json.JsonSerializer.Deserialize<List<Mascota>>(content, _options);
        return mascotas;
    }
}
