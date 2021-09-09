using SuppliesPriceLister.Domain;
using SuppliesPriceLister.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Repository
{
   public class OutputSuppliesDetail
    {

        private readonly IBaseFileReader _iDataReader;

        public OutputSuppliesDetail(IBaseFileReader dataReader)
        {
            _iDataReader = dataReader;
        }

        public void Load()
        {
            this._iDataReader.LoadDetails();
        }

        public List<OutputModel> GetSupplies()
        {
            return _iDataReader.SuppliesDetail;
        }
    }
}
