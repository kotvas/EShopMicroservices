using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product A",
                Description = "Description Product A",
                Category = new List<string>{ "Cat1", "Cat2"},
                ImageFile = "product-A.png",
                Price = 199
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product B",
                Description = "Description Product B",
                Category = new List<string>{ "Cat1", "Cat3"},
                ImageFile = "product-B.png",
                Price = 11
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product C",
                Description = "Description Product C",
                Category = new List<string>{ "Cat2", "Cat4"},
                ImageFile = "product-C.png",
                Price = 59
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product D",
                Description = "Description Product D",
                Category = new List<string>{ "Cat2", "Cat3", "Cat4"},
                ImageFile = "product-D.png",
                Price = 99
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product E",
                Description = "Description Product E",
                Category = new List<string>{ "Cat5"},
                ImageFile = "product-E.png",
                Price = 299
            }
        };
    }
}