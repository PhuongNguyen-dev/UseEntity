using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseEntity.Interfaces;
using UseEntity.Models;

namespace UseEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _ProdRepo;
        public ProductsController(IProductRepository prodRepo)
        {
            _ProdRepo = prodRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProd()
        {

            return Ok(await _ProdRepo.getAllProdAsync());


        }
        [HttpGet("{prodId}")]
        public async Task<IActionResult> GetProdBy(Guid prodId)
        {
            var prod = await _ProdRepo.getProdAsync(prodId);
            return prod == null ? NotFound() : Ok(prod);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProd(ProductModel model)
        {
            var newProd = await _ProdRepo.AddProdAsync(model);
            var prod = await _ProdRepo.getProdAsync(newProd);
            return prod == null ? NotFound() : Ok(prod);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProd( ProductModel model)
        {
            await _ProdRepo.UpdateProdAsync( model);
            return Ok();
        }
        [HttpDelete("{prodId}")]
        public async Task<IActionResult> DeleteProd(Guid prodId)
        {
            await _ProdRepo.DeleteProdAsync(prodId);
            return Ok();
        }
    }
}
