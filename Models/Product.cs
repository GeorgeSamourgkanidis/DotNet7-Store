using System;
using System.Collections.Generic;

namespace ASP_DotNet7_products.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}