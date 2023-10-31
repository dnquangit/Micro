using Contracts.Common.Interfaces;
using Product.API.Entities;
using Product.API.Persistence;

namespace Product.API.Repos.Interfaces
{
    public interface IProductRepo : IRepoBase<CatalogProduct, long, ProductContext>
    {
        Task<IEnumerable<CatalogProduct>> GetProducts();

        Task<CatalogProduct> GetProduct(long id);

        Task<CatalogProduct> GetProductByNo(string productNo);

        Task CreateProduct(CatalogProduct product);
        Task UpdateProduct(CatalogProduct product);
        Task DeleteProduct(long id);
    }
}
