using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuppliesPriceLister.Domain;
using SuppliesPriceLister.Repository;

namespace SuppliesPriceLister
{
    class Program
    {
        public static IConfigurationRoot configuration;
       

        static void Main(string[] args)
        {
            string filePath= ConfigurationManager.AppSettings["filePath"];
            configuration = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile("appsettings.json", false)
                .Build();

        
            try
            {
                ReadandWriteOutputFromFiles();
            }
            catch (Exception ex)
            {               
                Console.WriteLine(string.Format("EXCEPTION THROWN - {0}",ex.Message));
            }

        }
        public static void ReadandWriteOutputFromFiles()
        {
            //Get the file name form configuration
            string csvFileName = ConfigurationManager.AppSettings["csvFileName"];
            string jsonFileName = ConfigurationManager.AppSettings["JsonFileName"];

            Console.WriteLine("Reading the file - " + csvFileName);
           // read the csv file
           OutputSuppliesDetail suppliesDataFromCsv = new OutputSuppliesDetail(new CsvFileDetailReader(csvFileName));
            
            suppliesDataFromCsv.Load();

            //read the Json file
            Console.WriteLine("Reading the file  - " + jsonFileName);
            OutputSuppliesDetail suppliesDataFromJson = new OutputSuppliesDetail(new JsonFileDetailReader(jsonFileName, configuration));
           
            suppliesDataFromJson.Load();

            Console.WriteLine("Output: \n");
          
            //Formatted output
            WriteSuppliesDetails(suppliesDataFromCsv, suppliesDataFromJson);

            Console.ReadKey();
        }

        static void WriteSuppliesDetails(OutputSuppliesDetail csvSuppliesData, OutputSuppliesDetail jsonSuppliesData)
        {
            //order by price in cents desc
            var sortedSuppliesData = csvSuppliesData.GetSupplies().Concat(jsonSuppliesData.GetSupplies()).ToList().OrderByDescending(s => s.PriceInCents);

            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0}  {1}  {2}",$"{"Id",-40}",$"{"Item Name",-50}",$"{"Price",10}");            
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");

            foreach (OutputModel supply in sortedSuppliesData)
            {
                Console.WriteLine("{0}  {1}  {2}",
                    $"{supply.Id,-40}", 
                    $"{supply.ItemName,-50}", 
                    $"{supply.PriceInDollar,10:C}");
            }
        }
    }
}

