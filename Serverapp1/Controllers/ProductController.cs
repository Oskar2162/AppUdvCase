using Core;
using Microsoft.AspNetCore.Mvc;
using Serverapp1.Repositories;
using ServerApp1.Repositories;

namespace Serverapp1.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{

    private ProductRepository productRepo;

    public ProductController(ProductRepository productRepo) {
        this.productRepo = productRepo;
    }

    [HttpGet]
    public List<Product> Get()
    {
        return productRepo.GetAll();
    }

    [HttpPost]
    public void Add(Product p) {
        productRepo.Add(p);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public void Delete(int id)
    {
        productRepo.DeleteById(id);
    }
    
    [HttpDelete]
    [Route("delete")]
    public void DeleteByQuery([FromQuery]int id)
    {
        productRepo.DeleteById(id);
    }
}