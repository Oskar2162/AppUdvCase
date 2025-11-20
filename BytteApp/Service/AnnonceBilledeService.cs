using System.Net.Http;
using System.Net.Http.Json;

namespace BytteApp.Service;

public class AnnonceBilledeService : IAnnonceBilledeService
{
    private readonly HttpClient _http;

    // alle kald går mod api/files/...
    private const string BasePath = "api/files";

    public AnnonceBilledeService(HttpClient http)
    {
        _http = http;
    }

    // Upload billede til FileController
    public async Task<(bool success, string info)> SendFile(string filename, Stream stream)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(stream), "file", filename);

        var response = await _http.PostAsync($"{BasePath}/upload", content);

        var key = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return (true, key);  // key = filnavn
        }

        return (false, response.ReasonPhrase ?? "Ukendt fejl");
    }

    // Hent liste med alle filnavne
    public async Task<List<string>> GetAllKeys()
    {
        var keys =
            await _http.GetFromJsonAsync<List<string>>($"{BasePath}/getall")
            ?? new List<string>();

        return keys;
    }

    //  KORREKT: returnér fuld URL så billeder kan vises
    public string ConvertToUrl(string key)
    {
        var baseAddress = _http.BaseAddress?.ToString().TrimEnd('/');

        // Ex: http://localhost:5097/api/files/theimage.jpg
        return $"{baseAddress}/{BasePath}/{key}";
    }

    // Slet en fil fra serveren
    public async Task<(bool success, string info)> DeleteFile(string filename)
    {
        var resp = await _http.DeleteAsync($"{BasePath}/{filename}");

        if (resp.IsSuccessStatusCode)
        {
            return (true, "Fil slettet");
        }

        return (false, resp.ReasonPhrase ?? "Fejl ved sletning");
    }
}