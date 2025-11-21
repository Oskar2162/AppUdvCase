using System.Net.Http.Json;
using Core;

namespace BytteApp.Service;

public class AnnonceServiceHttp : AnnonceService
{
    private readonly HttpClient client;

    public AnnonceServiceHttp(HttpClient client) // kontruktør - 
    {
        this.client = client;
    }

    public Task<List<Annonce>?> GetAll() // Returnerer en opgave (Task) der, når den fuldføres, giver en liste af annoncer
    {
        return client.GetFromJsonAsync<List<Annonce>?>("api/annonce");
    }

    public async Task Add(Annonce annonce) // Tager en annonce som parameter og POST’er den som JSON til serverens api endpoint.
    {
        await client.PostAsJsonAsync("api/annonce", annonce);
    }

    public Task DeleteById(int id) // Kalder delete i AnnonceService for at slette en annonce
    {
        return client.DeleteAsync($"api/annonce/{id}");
    }

    public async Task SendPurchaseRequest(int annonceId, string userId) //Sender købsanmodning for det specifikke annonceID og bruger ID
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
