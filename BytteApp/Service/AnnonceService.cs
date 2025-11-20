using Core;

namespace BytteApp.Service;

public interface AnnonceService
{
    Task<List<Annonce>?> GetAll();
    Task Add(Annonce annonce);
    Task DeleteById(int id);
    Task SendPurchaseRequest(int annonceId, string userId);
    Task Approve(int id);
    Task Reject(int id);
}