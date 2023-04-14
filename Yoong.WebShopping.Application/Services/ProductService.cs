using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using UseEntity.Entities;
using UseEntity.Interfaces;
using UseEntity.Models;
using Yoong.WebShopping.Application.Models;
using Yoong.WebShopping.DAO.InterfacesDAO;

namespace UseEntity.Repositories
{
    public class ProductService : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly IProductDAO _prodDao;
        public ProductService(IProductDAO prodDao, IMapper mapper)
        {
            _prodDao = prodDao;
            _mapper = mapper;
        }

        public async Task<Guid> AddProdAsync(CreateProductModel model)
        {
            var newProd = _mapper.Map<Product>(model);
            _prodDao.CreateProduct(newProd);
            return await Task.FromResult(newProd.ProductId);
        }

        public async Task DeleteProdAsync(Guid productId)
        {
            var deleteProd = await _prodDao.GetByID(productId);
            if (deleteProd != null)
            {
                await _prodDao.DeleteProd(deleteProd);
            }
        }

        public async Task<List<ProductModel>> getAllProdAsync()
        {
            var prod = await _prodDao.GetAll();

            return _mapper.Map<List<ProductModel>>(prod);
        }

        public async Task<ProductModel> getProdAsync(Guid prodId)
        {
            var prod =await _prodDao.GetByID(prodId);

            return  _mapper.Map<ProductModel>(prod);
        }

        public async Task UpdateProdAsync(ProductModel model)
        {
            var updateProd = _mapper.Map<Product>(model);

            if (updateProd.ProductId == model.ProductId)
            {
                await _prodDao.UpdateProd(updateProd);
            }
            else
            {
                Console.WriteLine("ngiu vcd");
            }


        }

        



    }
}
