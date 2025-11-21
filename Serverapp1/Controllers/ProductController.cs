using Core;
using Microsoft.AspNetCore.Mvc;
using Serverapp1.Repositories;
using ServerApp1.Repositories;

namespace Serverapp1.Controllers;

// [ApiController] gør denne klasse til en API-controller
[ApiController]
// Route sættes til "api/product" (hardcoded her)
[Route("api/product")]
public class ProductController : ControllerBase
{
    // Repository-interface til produkter
    // Her bruger vi et interface (ProductRepository), som typisk bliver injiceret via dependency injection
    private ProductRepository productRepo;

    // Constructoren får et ProductRepository ind udefra (injection)
    public ProductController(ProductRepository productRepo) {
        // Vi gemmer det i feltet, så vi kan bruge det i resten af klassen
        this.productRepo = productRepo;
    }

    // GET: api/product
    // Henter alle produkter
    [HttpGet]
    public List<Product> Get()
    {
        // Kalder repositoryets GetAll(), som henter alle produkter fra databasen
        return productRepo.GetAll();
    }

    // POST: api/product
    // Opretter et nyt produkt
    [HttpPost]
    public void Add(Product p) {
        // Giver produktet videre til repositoryet, som står for at gemme det
        productRepo.Add(p);
    }

    // DELETE: api/product/delete/5
    // Sletter et produkt ud fra id, som del af URL'en
    [HttpDelete]
    [Route("delete/{id:int}")]
    public void Delete(int id)
    {
        // Beder repositoryet slette produktet med det givne id
        productRepo.DeleteById(id);
    }
    
    // DELETE: api/product/delete?id=5
    // Alternativ måde at slette på, hvor id kommer som query-parameter
    [HttpDelete]
    [Route("delete")]
    public void DeleteByQuery([FromQuery]int id)
    {
        // Samme logik som ovenfor – bare med id fra query string
        productRepo.DeleteById(id);
    }
}