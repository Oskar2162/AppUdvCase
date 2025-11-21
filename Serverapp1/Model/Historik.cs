using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverapp1.Model
{
    // Modelklasse for en købs-historik-post
    public class Historik
    {
        // Primært id for historik-posten (købet)
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int købid { get; set; }

        // Pris som der blev betalt ved købet
        public int price { get; set; }

        // Dato for købet (gemt som int her – kunne f.eks. være et årstal eller en dato-kode)
        public int købsdato { get; set; }
    }
}