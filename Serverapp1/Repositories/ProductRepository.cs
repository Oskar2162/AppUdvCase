using Core;
using Serverapp1.Model;

namespace ServerApp1.Repositories;

public interface ProductRepository
{
    List<Product> GetAll();
    void Add(Product p);
    void DeleteById(int id);

}