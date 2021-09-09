using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Domain
{
    public class OutputModel
    {
        public string Id { get; set; }
       
        public int PriceInCents { get; set; }
        public string ItemName { get; set; }
        public decimal PriceInDollar { get; set; }
    }
}
