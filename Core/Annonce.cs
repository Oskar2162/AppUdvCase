using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Core;

public class Annonce
{
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int annonceid { get; set; }

    public int price { get; set; }

    public string title { get; set; } = string.Empty;

    public string description { get; set; } = string.Empty;

    // Lokalitet-id (passer til jeres eksisterende Lokalitet-model)
    public int lid { get; set; }

    // Brug fx "Active" / "Inactive" som simple statusværdier
    public string Status { get; set; } = "Active";

    //  NØGLE TIL BILLEDET PÅ SERVEREN
    public string? imageKey { get; set; }
    
    // NYT: bruger-id som string (beholder format som hos LoginState/UserService)
    public string userid { get; set; }
}