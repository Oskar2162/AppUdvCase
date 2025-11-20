using Core;

namespace BytteApp.Service;

public interface AnnonceService
{
    Task<List<Annonce>?> GetAll();
    Task Add(Annonce annonce);
    Task DeleteById(int id);
}