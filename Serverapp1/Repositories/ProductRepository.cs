using Core;

namespace ServerApp1.Repositories;
using BytteApp.Models;

public interface ProductRepository
{
    List<Product> GetAll();
    void Add(Product p);
    void DeleteById(int id);

}