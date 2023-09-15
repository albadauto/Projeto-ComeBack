using ComeBack.API.DAO;
using ComeBack.API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
             _productRepository = productRepository;
        }

        [HttpPost("/product/insertnewproduct")]
        public async Task<ActionResult<ProductDAO>> InsertNewProduct([FromBody] ProductDAO dao)
        {
            try
            {
                await _productRepository.InsertProduct(dao);
                return Ok(new { success = true, message = "Produto inserido com sucesso"});
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message.ToString(), success = false });
            }

        }

        [HttpGet("/product/getallproducts")]
        public async Task<ActionResult<List<ProductDAO>>> GetAllProducts()
        {
            try
            {
                var result = await _productRepository.GetAllProducts();
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message.ToString(), success = false });
            }
        }
    }
}
