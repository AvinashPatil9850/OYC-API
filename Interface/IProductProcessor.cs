using OYC_API.Entities;
using OYC_API.Request;

namespace OYC_API.Interface
{
    public interface IProductProcessor
    {
        Task<List<Product>> GetAllProductList();
        Task<int> AddProduct(Product productRequest);
        Task<int> UpdateProduct(ProductRequest productRequest);
        Task<int>  DeleteProduct(DeleteProductRequest productRequest);

    }
}
