using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OYC_API.Data;
using OYC_API.Entities;
using OYC_API.Interface;
using OYC_API.Request;
using OYC_API.Response;
namespace OYC_API.Implimantation
{
    public class ProductProcessor:IProductProcessor
    {
        public readonly OycContext _context;
        public ProductProcessor(OycContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductList()
        {

             var response = _context.Product.FromSql<Product>($"SP_GetProductList").ToList();
           // var response = _context.Database.ExecuteSqlRaw($"SP_GetProductList");
            //var type = await _context.ProductType.Select(x => new ProductTypeResponse()
            //{
            //    ProductTypeId = x.ProductTypeId,
            //    ProductTypeName = x.ProductTypeName
            //}).ToListAsync();
            return await Task.FromResult(response);
        }
        public async Task<int> AddProduct(Product productRequest)
        {
            // var response = _context.Database.ExecuteSqlRaw($"SP_AddProduct {productRequest.ProductID},{productRequest.ProductName},{productRequest.ProductType},{productRequest.ProductPrice},{productRequest.ProductSrc},{productRequest.ProductFileName}");
            var product = new Product()
            {
                ProductName = productRequest.ProductName,
                ProductPrice = productRequest.ProductPrice,
                ProductType = productRequest.ProductType,
                ProductFileName = productRequest.ProductFileName,
                ProductSrc = productRequest.ProductSrc
            };
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductID;
        }
        public async Task<int> UpdateProduct(ProductRequest productRequest)
        {
            var response = _context.Database.ExecuteSqlRaw($"SP_UpdateProduct {productRequest.ProductID},{productRequest.ProductName},{productRequest.ProductType},{productRequest.ProductPrice},{productRequest.ProductSrc},{productRequest.ProductFileName}");
            return response;
        }

        public async Task<int> DeleteProduct(DeleteProductRequest productRequest)
        {
            var response = _context.Database.ExecuteSqlRaw($"SP_DeleteProduct {productRequest.ProductID}");
            return response;
        }
    }
}
