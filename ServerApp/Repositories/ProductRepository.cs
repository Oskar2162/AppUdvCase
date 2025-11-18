namespace ServerApp.Repositories;
using Core;

public interface ProductRepository
{
    List<Product> GetAll();
    void Add(Product p);
    void DeleteById(int id);

}