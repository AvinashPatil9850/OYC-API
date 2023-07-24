using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OYC_API.Data;
using OYC_API.Entities;
using OYC_API.Interface;
using OYC_API.Request;
using OYC_API.Response;

namespace OYC_API.Implimantation
{
    public class ProductTypeProcessor : IProductTypeProcessor
    {
        public readonly OycContext _context;
        public ProductTypeProcessor(OycContext context)
        {
            _context = context;
        }

        public async Task<List<ProductType>> GetAllProductTypeList()
        {

            var response = _context.ProductType.FromSql<ProductType>($"SP_GetProductTypeList").ToList();
            //var type = await _context.ProductType.Select(x => new ProductTypeResponse()
            //{
            //    ProductTypeId = x.ProductTypeId,
            //    ProductTypeName = x.ProductTypeName
            //}).ToListAsync();
            return await Task.FromResult(response);
        }
        public async Task<int>AddProductType(ProductTypeRequest productTypeRequest)
        {

           var response= _context.Database.ExecuteSqlRaw($"SP_AddProductType {productTypeRequest.ProductTypeId},{productTypeRequest.ProductTypeName}");
            return response;
        }
        public async Task<int> UpdateProductType(ProductTypeRequest productTypeRequest)
        {
            var response = _context.Database.ExecuteSqlRaw($"SP_UpdateProductType {productTypeRequest.ProductTypeId},{productTypeRequest.ProductTypeName}");
            return response;
        }

        public async Task<int> DeleteProductType(ProductTypeRequest productTypeRequest)
        {
            var response = _context.Database.ExecuteSqlRaw($"SP_DeleteProductType {productTypeRequest.ProductTypeId}");
            return response;
        }
    }
}
