using System.Net.Http.Json;
using Core;
namespace BytteApp.Service;

public class ProductServiceHttp : ProductService
{
    
    private HttpClient client;
    
    public ProductServiceHttp(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<Product>?> GetAll()
    {
        return await client.GetFromJsonAsync<List<Product>?>($"api/product");
    }

    public async Task Add(Product p)
    {
        await client.PostAsJsonAsync($"api/product", p);
    }

    public async Task DeleteById(int id)
    {
        var endPoint = $"{Server.Url}/api/product/{id}";
        await client.DeleteAsync(endPoint);
    }
}