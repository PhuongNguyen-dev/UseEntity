using UseEntity.Entities;
using UseEntity.Models;
using Yoong.WebShopping.Application.Models;

namespace UseEntity.Interfaces
{
    public interface IProductRepository
    {
        public Task<Guid> AddProdAsync(CreateProductModel model);
        public Task<List<ProductModel>> getAllProdAsync();
        public Task<ProductModel> getProdAsync(Guid productId);
        public Task UpdateProdAsync(ProductModel model);
        public Task DeleteProdAsync(Guid productId);
    }
}
