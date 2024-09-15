﻿using System.Text.Json.Serialization;

namespace SimplyNotAlwaysUp.Modals
{
    internal record Page
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required Uri Url { get; set; }

        [JsonPropertyName("time_zone")]
        public required string TimeZone { get; set; }

        [JsonPropertyName("updated_at")]
        public required DateTime UpdatedAt { get; set; }
    }
}
