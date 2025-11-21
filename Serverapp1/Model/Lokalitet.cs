using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverapp1.Model
{
    // Modelklasse for en lokalitet (sted, by, butik osv.)
    public class Lokalitet
    {
        // Primært id for lokaliteten
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int lokalitetid { get; set; }

        // Navn på lokaliteten (f.eks. "København", "Butik A")
        public string LName { get; set; }

        // Liste over alle annoncer, der hører til denne lokalitet
        public List<Annonce> Annonces { get; set; } = new List<Annonce>();
    }
}