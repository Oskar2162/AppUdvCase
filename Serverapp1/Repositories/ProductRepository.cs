using Core;
using Serverapp1.Model;

namespace ServerApp1.Repositories;


public interface ProductRepository
{
    // Skal kunne hente alle produkter
    List<Product> GetAll();

    // Skal kunne tilføje et nyt produkt
    void Add(Product p);

    // Skal kunne slette et produkt ud fra id
    void DeleteById(int id);

}