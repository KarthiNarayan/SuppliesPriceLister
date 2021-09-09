using SuppliesPriceLister.Domain;
using SuppliesPriceLister.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace SuppliesPriceLister.Repository
{
    public abstract class BaseFileReader : IBaseFileReader
    {
        public abstract void LoadDetails();

        public List<OutputModel> SuppliesDetail { get; set; }

        public string GetFilePath(string fileName)
        {
            string filePath = ConfigurationManager.AppSettings["filePath"];

            return filePath + "\\Inputs" + "\\" + fileName;
        }

    }
}
