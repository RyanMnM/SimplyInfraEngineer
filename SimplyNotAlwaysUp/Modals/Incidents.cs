using System.Text.Json.Serialization;

namespace SimplyNotAlwaysUp.Modals
{
    internal record Incidents
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        [JsonPropertyName("created_at")]

        public required DateTime CreatedAt { get; set; }

        public required string Status { get; set; }
    }
    internal record IncidentsResponse
    {
        public required Page Page { get; set; }

        public required IList<Incidents> Incidents { get; set; }
    }
}