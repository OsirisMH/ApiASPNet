using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading.Tasks;

namespace API.Models
{
    public class Pagos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("NumeroMatricula")]
        public string NumeroMatricula { get; set; } = null!;
        [BsonElement("TipoPago")]
        public string TipoPago { get; set; } = null!;
        [BsonElement("Institucion")]
        public string Institucion { get; set; } = null!;
        [BsonElement("Descripcion")]
        public string Descripcion { get; set; } = null!;
        [BsonElement("Nombre")]
        public string Nombre { get; set; } = null!;
        [BsonElement("Apellidos")]
        public string Apellidos { get; set; } = null!;
        [BsonElement("Fecha")]
        public string Fecha { get; set; } = null!;
        
    }
}