using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;
using Yoong.WebShopping.DAO.InterfacesDAO;

namespace Yoong.WebShopping.DAO.ServiceDAO
{
    public class ProductDAO : IProductDAO
    {
        private readonly IMapper _mapper;
        private readonly WebShopContext _context;
        public ProductDAO(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public Task<Product?> GetByID(Guid prodId)
        {
            return  _context.Products!.FirstOrDefaultAsync(p=> p.ProductId==prodId);
        }
        
        public async Task DeleteProd(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();

        }

        public async Task<Product> UpdateProd(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products!.ToListAsync();
        }

       
    }
}
