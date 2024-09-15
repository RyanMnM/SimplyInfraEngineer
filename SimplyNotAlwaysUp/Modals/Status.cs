namespace SimplyNotAlwaysUp.Modals
{
    internal enum Indicator { none, minor, major, critical }

    internal record Status
    {
        public required Indicator Indicator { get; set; }

        public required string Description { get; set; }
    }

    internal record StatusResponse
    {
        public required Page Page { get; set; }

        public required IList<Status> Status { get; set; }
    }

}
