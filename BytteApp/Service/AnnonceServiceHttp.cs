using System.Net.Http.Json;
using Core;

namespace BytteApp.Service;

public class AnnonceServiceHttp : AnnonceService
{
    private readonly HttpClient client;

    public AnnonceServiceHttp(HttpClient client)
    {
        this.client = client;
    }

    public Task<List<Annonce>?> GetAll()
    {
        return client.GetFromJsonAsync<List<Annonce>?>("api/annonce");
    }

    public Task<List<Annonce>?> GetByUser(string userid)
    {
        // Bruger nyt endpoint i AnnonceController: GET api/annonce/by-user/{userid}
        return client.GetFromJsonAsync<List<Annonce>?>(@$"api/annonce/by-user/{userid}");
    }

    public async Task Add(Annonce annonce)
    {
        await client.PostAsJsonAsync("api/annonce", annonce);
    }

    public Task DeleteById(int id)
    {
        return client.DeleteAsync($"api/annonce/{id}");
    }
}