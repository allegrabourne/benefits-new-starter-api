namespace Benefits.Starter.Api.Endpoints.Employees
{
    public sealed class AddressDto
    {
        public string Line1 { get; set; } = default!;
        public string? Line2 { get; set; }
        public string City { get; set; } = default!;
        public string Postcode { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
}
