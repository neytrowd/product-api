using System.Text.Json;
using ProductApi.Contract.Models;
using ProductApi.Contract.Api.Resume.Request;

namespace ProductApi.Services.Product
{
    public class ProductService: IProductService
    {
        private string _dbPath;
        private IWebHostEnvironment _hostEnvironment;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContext;

        public ProductService(
            IWebHostEnvironment environment,
            IConfiguration configuration,
            IHttpContextAccessor httpContext)
        {
            _hostEnvironment = environment;
            _configuration = configuration;
            _httpContext = httpContext;
            _dbPath = Path.Combine(_hostEnvironment.ContentRootPath, "db.txt");
        }
        
        public async Task<List<ProductModel>> GetProducts(string? brand, int? count)
        {
            var jsonData = File.ReadAllText(_dbPath);
            var productsList = JsonSerializer.Deserialize<List<ProductModel>>(jsonData);

            if (!String.IsNullOrEmpty(brand))
            {
                productsList = productsList.Where(x => x.Brand == brand).ToList();
            }
            
            if (count.HasValue)
            {
                productsList = productsList.Take((int)count).ToList();
            }
            
            return productsList;
        }

        public async Task<ProductModel> CreateProduct(CreateProductRequest request)
        {
            var productModel = new ProductModel()
            {
                Id =  Guid.NewGuid().ToString(),
                Name = request.Name,
                Price = request.Price,
                Brand = request.Brand,
            };

            var jsonData = File.ReadAllText(_dbPath);
            var productList = JsonSerializer.Deserialize<List<ProductModel>>(jsonData);
            productList.Add(productModel);
            File.WriteAllText(_dbPath, JsonSerializer.Serialize(productList));

            return productModel;
        }
    }
}