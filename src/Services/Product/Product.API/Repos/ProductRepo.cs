using Contracts.Common.Interfaces;
using Infras.Common;
using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repos.Interfaces;

#nullable disable
namespace Product.API.Repos
{
    public class ProductRepo : RepoBase<CatalogProduct, long, ProductContext>, IProductRepo
    {
        public ProductRepo(ProductContext dbContext, IUnitOfWork<ProductContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public Task CreateProduct(CatalogProduct product)
        {
            return CreateAsync(product);
        }

        public async Task DeleteProduct(long id)
        {
            var product = await GetProduct(id);
            if (product != null)
            {
                await DeleteAsync(product);
            }

        }

        public async Task<CatalogProduct> GetProduct(long id)
        {
            return await GetByIdAsync(id);
        }

        public Task<CatalogProduct> GetProductByNo(string productNo)
        {
            return FindByCondition(x => x.No.Equals(productNo)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CatalogProduct>> GetProducts()
        {
            return await FindAll().ToListAsync();
        }

        public Task UpdateProduct(CatalogProduct product)
        {
            return UpdateAsync(product);
        }
    }
}
