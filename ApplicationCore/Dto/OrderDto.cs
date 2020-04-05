using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
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
