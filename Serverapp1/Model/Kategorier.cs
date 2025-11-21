using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverapp1.Model
{
    // Modelklasse for en kategori (bruges bl.a. som "booking" i UsersRepository)
    public class Kategorier
    {
        // Primært id for kategorien
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int kategorierid { get; set; }

        public DateTime Now { get; set; }

        public int NumSeats { get; set; }

        public Annonce Annonce { get; set; }
    }
}