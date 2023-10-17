using ProductApi.Contract.Api.Resume.Request;
using ProductApi.Contract.Models;

namespace ProductApi.Services.Product
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts(string brand, int? count);

        Task<ProductModel> CreateProduct(CreateProductRequest request);
    }
}