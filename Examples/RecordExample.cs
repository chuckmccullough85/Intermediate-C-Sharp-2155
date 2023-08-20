namespace Examples
{
    public record AddressInfo(string Street, string City, string State, string ZipCode)
    {
        public string? Apartment { get; set; }
        public string City { get; set; } = City;
    }
}
