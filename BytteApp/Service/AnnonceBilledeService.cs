using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            // key er filnavnet som FileController har lavet
            return (true, key);
        }

        return (false, response.ReasonPhrase ?? "Ukendt fejl");
    }

    // Hent liste med alle fil-navne
    public async Task<List<string>> GetAllKeys()
    {
        var keys =
            await _http.GetFromJsonAsync<List<string>>($"{BasePath}/getall")
            ?? new List<string>();

        return keys;
    }

    // Byg URL (HttpClient.BaseAddress + relative path)
    public string ConvertToUrl(string key)
    {
        // hvis HttpClient har BaseAddress = "http://localhost:5092/"
        // bliver det til: http://localhost:5092/api/files/{key}
        return $"{BasePath}/{key}";
    }

    // Slet en fil
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