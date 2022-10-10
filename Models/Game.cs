using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace beginning_mongodb_atlas_dotnet.Models
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = String.Empty;

        [Required]
        public string Name { get; set; }

        [Required]

        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

    }
}
