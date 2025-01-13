using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsResult(IEnumerable<Product> Products);
}