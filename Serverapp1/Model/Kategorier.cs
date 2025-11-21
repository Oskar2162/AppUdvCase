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

        // Tidspunkt (nu) – hvornår kategorien/booking er oprettet
        public DateTime Now { get; set; }

        // Antal pladser/sæder (fx hvor mange der kan booke denne kategori)
        public int NumSeats { get; set; }

        // En reference til en Annonce, der hører til denne kategori
        public Annonce Annonce { get; set; }
    }
}