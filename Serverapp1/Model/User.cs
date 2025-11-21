using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverapp1.Model
{
    // Modelklasse for en bruger i systemet
    public class User
    {
        // Primært id for brugeren
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int userid { get; set; }

        // Brugernavn / login-id
        public string UserNameid { get; set; }

        // Brugerens rigtige navn
        public string Name { get; set; }

        // Adgangskode (gemt som ren tekst her – i praksis bør den hashes)
        public string Password { get; set; }

        // Brugerens e-mailadresse
        public string Email { get; set; }

        // Brugerens telefonnummer
        public int PhoneNumber { get; set; }

        // Liste af Tannonce-objekter, der hører til denne bruger
        public List<Tannonce> tannonces { get; set; } = new List<Tannonce>();
    }
}