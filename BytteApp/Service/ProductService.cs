using Core;
namespace BytteApp.Service;

public interface ProductService
{
    Task<List<Product>?> GetAll();
    Task Add(Product bike);
    Task DeleteById(int id); 
}