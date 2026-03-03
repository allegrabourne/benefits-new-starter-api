using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Domain
{
    public sealed class Address
    {
        public string Line1 { get; private set; } = default!;
        public string? Line2 { get; private set; }
        public string City { get; private set; } = default!;
        public string Postcode { get; private set; } = default!;
        public string Country { get; private set; } = "UK";

        private Address() { }

        public Address(string line1, string? line2, string city, string postcode, string? country = null)
        {
            Line1 = string.IsNullOrWhiteSpace(line1) ? throw new ArgumentException("Address line 1 is required.") : line1.Trim();
           
            Line2 = string.IsNullOrWhiteSpace(line2) ? null : line2.Trim();
            
            City = string.IsNullOrWhiteSpace(city) ? throw new ArgumentException("City is required.") : city.Trim();
            
            Postcode = string.IsNullOrWhiteSpace(postcode) ? throw new ArgumentException("Postcode is required.") : postcode.Trim();
            
            Country = string.IsNullOrWhiteSpace(country) ? "UK" : country.Trim();
        }
    }
}
