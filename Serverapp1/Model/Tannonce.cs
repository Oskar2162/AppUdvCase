using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverapp1.Model
{
    // Modelklasse for Tannonce – ligner Annonce, men med eget id
    public class Tannonce
    {
        // Primært id for Tannonce
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int tannonceid { get; set; }

        // Pris på Tannonce
        public int price { get; set; }

        // Titel på Tannonce
        public string title { get; set; }

        // Beskrivelse
        public string description { get; set; }

        // Id på lokalitet
        public int lid { get; set; }

        // Status (f.eks. "Aktiv", "Solgt")
        public string Status { get; set; }
    }
}