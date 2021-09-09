using SuppliesPriceLister.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuppliesPriceLister.Repository
{
    public class CsvFileDetailReader : BaseFileReader
    {

            private string FilePath { get; set; }

            public CsvFileDetailReader(string fileName)
            {
                if (string.IsNullOrEmpty(fileName))
                    throw new ArgumentException("File Name should not be null or empty.");

            if (!fileName.Contains(".csv"))
                 throw new ArgumentException("Invalid file format.");

            FilePath = GetFilePath(fileName);
            }

            public override void LoadDetails()
            {
                SuppliesDetail = (from data in File.ReadAllLines(this.FilePath).Skip(1)
                           let m = data.Split(',')
                           select new OutputModel
                           {
                               Id = m[0],
                               ItemName = m[1],
                               PriceInCents = Convert.ToInt32(Math.Round(Convert.ToDecimal(m[3]), 2) * 100),
                               PriceInDollar = GetRoundedValue(Convert.ToInt32(Math.Round(Convert.ToDecimal(m[3]), 2) * 100) / 100m)
                           }).ToList();
            }


     

        private decimal GetRoundedValue(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.ToEven);
        }
    }
}
