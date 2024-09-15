using System.Text.Json.Serialization;

namespace SimplyNotAlwaysUp.Models
{
    /*
     * Enum to handle the hard coded `Indicator` section
     * `JsonConverter` used to allow `System.Text.Json` to handle the conversion from a plain string
     */
    [JsonConverter(typeof(JsonStringEnumConverter<Indicator>))]
    public enum Indicator { none, minor, major, critical }

    /*
     * POD Record for the `Status` section of all Status responses
     */
    internal record Status
    {
        public required Indicator Indicator { get; set; }

        public required string Description { get; set; }
    }

    /*
     * POD Record for the `StatusResponse`
     * Made up of a `Page` section and a `Status` section
     */
    internal record StatusResponse
    {
        public required Page Page { get; set; }

        public required Status Status { get; set; }
    }
}
