using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SuppliesPriceLister.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SuppliesPriceLister.Repository
{
    public class JsonFileDetailReader : BaseFileReader
    {

        private string FilePath { get; set; }
        private decimal ExchangeRate { get; set; }

        public JsonFileDetailReader(string fileName, IConfigurationRoot configuration)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("FileName cannot be null or empty.");

            if (configuration == null)
                throw new ArgumentException("Configuration cannot be null.");

            if(!fileName.Contains(".json"))
                throw new ArgumentException("Invalid file format.");

            FilePath = GetFilePath(fileName);

            decimal exchangeRate = Convert.ToDecimal(configuration.GetSection("audUsdExchangeRate").Value);
            ExchangeRate = 1 / exchangeRate;
        }

        public override void LoadDetails()
        {
            using StreamReader file = new StreamReader(FilePath);
            string json = file.ReadToEnd();
            var data = JsonConvert.DeserializeObject<JsonDetailModel>(json);
            if (data != null)
                SuppliesDetail = data.Partners.SelectMany(p => p.Supplies).Select(s => new SuppliesPriceLister.Domain.OutputModel
                {
                    Id = s.Id.ToString(),
                    ItemName = s.Description,
                    PriceInCents = Convert.ToInt16(s.PriceInCents * ExchangeRate),
                    PriceInDollar = GetRoundedValue(Convert.ToInt16(s.PriceInCents * ExchangeRate) / 100m)
                }).ToList();
        }

        private decimal GetRoundedValue(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.ToEven);
        }

    }
}

