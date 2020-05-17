using System.Collections.Generic;

namespace Core.Dto
{
    public sealed class OrderDto
    {
        public int Id { get;  }
        public string Name { get; }
        public string Line1 { get; }
        public string Line2 { get; }
        public string Line3 { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }
        public string Country { get; }
        public bool GiftWrap { get; }
        public bool Shipped { get; }
        public ICollection<CartLineDto> Lines { get; set; }

        public OrderDto(int id, string name, string line1, string line2, string line3, string city, string state, string country, string zip,  bool giftWrap, bool shipped, ICollection<CartLineDto> lines)
        {
            Id = id;
            Name = name;
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            GiftWrap = giftWrap;
            Shipped = shipped;
            Lines = lines;
        }
    }
}
