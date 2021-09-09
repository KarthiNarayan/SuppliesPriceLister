using Moq;
using NUnit.Framework;
using SuppliesPriceLister.Repository;
using SuppliesPriceLister;
using System;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;
using System.Linq;

namespace SuppliesPriceListerTest
{
    public class Tests
    {
		private BaseFileReader _baseReader;
		private Mock<OutputSuppliesDetail> _mockOutputSuppliesDetailMok;
		private CsvFileDetailReader _csvReader;
		private JsonFileDetailReader _jsonReader;
		string fileName = "humphries.csv";


		[SetUp]
		public void SetUp()
		{
			_mockOutputSuppliesDetailMok = new Mock<OutputSuppliesDetail>();
			
		}

		[TearDown]
		public void TearDown()
		{
			_mockOutputSuppliesDetailMok = null;
			_csvReader = null;
			_jsonReader = null;
		}
		[Test]
        public void Test_GIVEN_CSV_FILE_EXISTS()
        {			
			//Check whether able to access the file in the provided path
			Assert.IsNotNull(new CsvFileDetailReader(fileName).GetFilePath(fileName));
		}

		[Test]
		public void Test_CsvFileFormat()
		{			
			//Check whether able to access the file in the provided path
			Assert.Throws(typeof(ArgumentException), () =>new CsvFileDetailReader("humphries.json"));
		}

		[Test]
		public void Test_GIVEN_JSON_FILE_EXISTS()
		{
			string filePath = ConfigurationManager.AppSettings["filePath"];
			IConfigurationRoot configuration =  new ConfigurationBuilder()
				.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
				.AddJsonFile("appsettings.json", false)
				.Build();
			//initialize the reader
			_jsonReader = new JsonFileDetailReader("megacorp.json",configuration);
			//Check whether able to access the file in the provided path
			Assert.IsNotNull(new JsonFileDetailReader("megacorp.json", configuration));

		}

		[Test]
		public void Test_READFILE_LoadDetails()
        {
			_mockOutputSuppliesDetailMok = new Mock<OutputSuppliesDetail>();
			 OutputSuppliesDetail suppliesDataFromCsv = new OutputSuppliesDetail(new CsvFileDetailReader("D:\\supplies - price - lister\\buildxact - supplies - price - lister - 830fc692c659"+ fileName));

			Assert.Throws(typeof(ArgumentNullException), () => suppliesDataFromCsv.GetSupplies().ToList());
		}

	}
}