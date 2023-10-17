namespace ProductApi.Contract.Api.Resume.Request
{
    public class CreateProductRequest
    {
        public string Name { get; set; }

        public double Price { get; set; }
        
        public string Brand { get; set; }
    }
}