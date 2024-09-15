namespace SimplyNotAlwaysUp.Modals
{
    internal record Page
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required Uri Url { get; set; }

        public required TimeZoneInfo TimeZone { get; set; }

        public required DateTime UpdatedAt { get; set; }
    }
}
