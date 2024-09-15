using System.Text.Json.Serialization;

namespace SimplyNotAlwaysUp.Models
{
    /*
     * POD Record for the `Incidents` section of all Incidents responses
     */
    internal record Incidents
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        [JsonPropertyName("created_at")]

        public required DateTime CreatedAt { get; set; }

        public required string Status { get; set; }
    }

    /*
     * POD Record for the `IncidentsResponse`
     * Made up of a `Page` section and a list of `Incidents`
     */
    internal record IncidentsResponse
    {
        public required Page Page { get; set; }

        public required IList<Incidents> Incidents { get; set; }
    }
}