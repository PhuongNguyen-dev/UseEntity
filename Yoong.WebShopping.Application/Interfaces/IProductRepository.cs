using UseEntity.Models;

namespace UseEntity.Interfaces
{
    public interface IProductRepository
    {
        public Task<Guid> AddProdAsync(ProductModel model);
        public Task<List<ProductModel>> getAllProdAsync();
        public Task<ProductModel> getProdAsync(Guid productId);
        public Task UpdateProdAsync( ProductModel model);
        public Task DeleteProdAsync(Guid productId);
    }
}
