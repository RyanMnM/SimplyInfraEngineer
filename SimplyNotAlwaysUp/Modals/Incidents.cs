namespace SimplyNotAlwaysUp.Modals
{
    internal record Incidents
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required DateTime CreatedAt { get; set; }

        public required string Status { get; set; }
    }
}