using Core;

namespace BytteApp.Service;

public interface AnnonceService
{
    Task<List<Annonce>?> GetAll();
    Task<List<Annonce>?> GetByUser(string userid);
    Task Add(Annonce annonce);
    Task DeleteById(int id);
}