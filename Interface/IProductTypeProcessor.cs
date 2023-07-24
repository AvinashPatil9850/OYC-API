using OYC_API.Entities;
using OYC_API.Request;
using OYC_API.Response;

namespace OYC_API.Interface
{
    public interface IProductTypeProcessor
    {
        Task<List<ProductType>> GetAllProductTypeList();
        Task<int> AddProductType(ProductTypeRequest productTypeRequest);
        Task<int> DeleteProductType(ProductTypeRequest productTypeRequest);
        Task<int> UpdateProductType(ProductTypeRequest productTypeRequest);
    }
}
