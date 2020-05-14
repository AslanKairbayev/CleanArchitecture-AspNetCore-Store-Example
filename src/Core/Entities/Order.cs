﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Order 
    {
        public int Id { get; set; }        
        public bool Shipped { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        public ICollection<CartLine> Lines { get; set; }
    }
}
