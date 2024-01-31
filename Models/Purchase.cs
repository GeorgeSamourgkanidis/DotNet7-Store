using System;
using System.Collections.Generic;

namespace ASP_DotNet7_products.Models
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}