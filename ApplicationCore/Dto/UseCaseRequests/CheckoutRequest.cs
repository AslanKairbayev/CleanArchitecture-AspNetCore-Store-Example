using ApplicationCore.Dto.UseCaseResponses;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTO
{
    public class CheckoutRequest : IRequest<CheckoutResponse>
    {        
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        public ICollection<CartLineDTO> Lines { get; set; }

        public CheckoutRequest(string name, string line1, string city, string state, string country, string zip = null, string line2 = null, string line3 = null, bool giftWrap = false)
        {
            Name = name;
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            GiftWrap = giftWrap;
        }
    }
}
