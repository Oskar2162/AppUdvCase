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

    public async Task Add(Annonce annonce)
    {
        await client.PostAsJsonAsync("api/annonce", annonce);
    }

    public Task DeleteById(int id)
    {
        return client.DeleteAsync($"api/annonce/{id}");
    }

    public async Task SendPurchaseRequest(int annonceId, string userId)
    {
        var body = JsonContent.Create(userId);
        var resp = await client.PostAsync($"api/annonce/purchase/{annonceId}", body);
    }
    public async Task Approve(int id)
    {
        await client.PostAsync($"api/annonce/approve/{id}", null);
    }

    public async Task Reject(int id)
    {
        await client.PostAsync($"api/annonce/reject/{id}", null);
    }
}
