using Core;

namespace BytteApp.Service;

public interface AnnonceService
{
    Task<List<Annonce>?> GetAll();
    Task Add(Annonce annonce);
    Task DeleteById(int id);
    Task SendPurchaseRequest(int id);
}

public async Task<bool> SendPurchaseRequest(string annonceId)
{
    var filter = Builders<Annonce>.Filter.Eq(a => a.annonceid, annonceId);

    var update = Builders<Annonce>.Update
        .Set(a => a.Status, "Der er sendt en købsanmodning");

    var result = await _annonceCollection.UpdateOneAsync(filter, update);

    return result.ModifiedCount > 0;
}