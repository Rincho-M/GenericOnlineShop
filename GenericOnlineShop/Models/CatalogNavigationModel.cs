using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Models
{
    public class CatalogNavigationModel
    {
        public IEnumerable<string> ProductTypeNames { get; set; }

        public CatalogNavigationModel(IEnumerable<string> productTypeNames)
        {
            ProductTypeNames = productTypeNames;
        }
    }
}
