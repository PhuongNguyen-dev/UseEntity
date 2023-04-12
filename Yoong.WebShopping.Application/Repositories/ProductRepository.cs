using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using UseEntity.Entities;
using UseEntity.Interfaces;
using UseEntity.Models;

namespace UseEntity.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly WebShopContext _context;
        public ProductRepository(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddProdAsync(ProductModel model)
        {
            var newProd = _mapper.Map<Product>(model);
            _context.Add(newProd);
            await _context.SaveChangesAsync();
            return newProd.ProductId;

        }

        public async Task DeleteProdAsync(Guid productId)
        {
            var deleteProd = _context.Products.SingleOrDefault(x => x.ProductId == productId);
            if (deleteProd != null)
            {
                _context.Products.Remove(deleteProd);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductModel>> getAllProdAsync()
        {
            var prod = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(prod);
        }

        public async Task<ProductModel> getProdAsync(Guid productId)
        {
            var prod = await _context.Products!.FindAsync(productId);
            return _mapper.Map<ProductModel>(prod);
        }

        public async Task UpdateProdAsync(ProductModel model)
        {
            var updateProd = _mapper.Map<Product>(model);
            
            if (updateProd.ProductId == model.ProductId)
            {
                _context.Update(updateProd);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("ngiu vcd");
            }
        }
    }
}
