using SuppliesPriceLister.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Interface
{
    public interface IBaseFileReader
    {       
            List<OutputModel> SuppliesDetail { get; set; }
            void LoadDetails();
        
    }
}
