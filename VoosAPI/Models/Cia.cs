using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoosAPI.Models
{
    public class Cia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        [BsonElement("Nome Empresas")]
        public string NomeEmpresa { get; set; }

        [BsonElement("Sigla OACI")]
        public string SiglaOACI { get; set; }

        [BsonElement("Nacional ou Estrangeira")]
        public string NacionalEstrangeira { get; set; }

    }
}
