using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Domain
{
    public class JsonDetailModel
    {
        public List<PartnerDetail> Partners { get; set; }
    }
    public class PartnerDetail
    {
        public string Name { get; set; }
        public string PartnerType { get; set; }
        public string PartnerAddress { get; set; }
        public List<SupplyDetail> Supplies { get; set; }
    }

    public class SupplyDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public int PriceInCents { get; set; }
        public string ProviderId { get; set; }
        public string MaterialType { get; set; }
    }
}

   

