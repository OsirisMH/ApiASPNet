using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class Pagos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("numero_matricula")]
        public string NumeroMatricula { get; set; } = null!;
        [BsonElement("tipopago")]
        public string TipoPago { get; set; } = null!;
        [BsonElement("institucion")]
        public string Institucion { get; set; } = null!;
        [BsonElement("nombre")]
        public string Nombre { get; set; } = null!;
        [BsonElement("apellidos")]
        public string Apellidos { get; set; } = null!;
        [BsonElement("fecha")]
        public DateTime Fecha { get; set; }
        [BsonElement("descripcion")]
        public string Descripcion { get; set; } = null!;

    }
}