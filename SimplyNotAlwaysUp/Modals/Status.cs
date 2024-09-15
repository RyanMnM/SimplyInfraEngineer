namespace SimplyNotAlwaysUp.Modals
{
    internal enum Indicator { none, minor, major, critical }

    internal record Status
    {
        public required Indicator Indicator { get; set; }

        public required string Description { get; set; }
    }
}
