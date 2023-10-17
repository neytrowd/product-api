using Microsoft.AspNetCore.Mvc;
using ProductApi.Contract.Api.Resume.Request;
using ProductApi.Contract.Api.Resume.Response;
using ProductApi.Services.Product;

namespace ProductApi.Controllers
{
    [Route("api/resume")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<GetProductsResponse> GetProducts([FromQuery] string? brand, int? count)
        {
            var products = await _productService.GetProducts(brand, count);
            
            return new GetProductsResponse()
            {
                Products = products
            };
        }

        [HttpPost]
        public async Task<CreateProductResponse> CreateProduct([FromForm] CreateProductRequest request)
        {
            var product = await _productService.CreateProduct(request);

            return new CreateProductResponse()
            {
                Product = product
            };
        }
    }
}