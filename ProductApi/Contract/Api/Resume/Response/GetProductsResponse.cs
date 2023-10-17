using ProductApi.Contract.Models;

namespace ProductApi.Contract.Api.Resume.Response
{
    public class GetProductsResponse
    {
        public List<ProductModel> Products { get; set; }
    }
}