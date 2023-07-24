using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OYC_API.Data;
using OYC_API.Entities;
using OYC_API.Interface;
using OYC_API.Request;

namespace OYC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        public readonly IProductTypeProcessor _productTypeProcessor;
        public readonly OycContext _context;
        public ProductTypeController(OycContext context, IProductTypeProcessor  productTypeProcessor)
        {
            _productTypeProcessor = productTypeProcessor;
            _context = context;
        }
        [HttpGet]
        [Route("GetProductTypeList")]
        public async Task<IActionResult> GetAllProductTypeList()
        {
            try
            {
                var response = await _productTypeProcessor.GetAllProductTypeList();
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AddProductType")]
        public async Task<IActionResult> AddProductType([FromBody] ProductType productTypeRequest)
        {
            try
            {
                _context.ProductType.Add(productTypeRequest);
                
                await _context.SaveChangesAsync();
                return Ok();
                //  var id = await _productTypeProcessor.AddProductType(productTypeRequest);
                //    return CreatedAtAction(nameof(GetAllProductTypeList), new { id = id, Controller = "ProductType" }, id);
            }
            catch(Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
           
        }
        [HttpDelete]
        [Route("DeleteProductType")]
        public async Task<IActionResult> DeleteProductType([FromBody] ProductTypeRequest productTypeRequest)
        {
            try
            {
                var id = await _productTypeProcessor.DeleteProductType(productTypeRequest);
                return CreatedAtAction(nameof(GetAllProductTypeList), new { id = id, Controller = "ProductType" }, id);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

        }
        [HttpPut]
        [Route("UpdateProduct")]
        
        public async Task<IActionResult> UpdateProductType([FromBody] ProductTypeRequest productTypeRequest)
        {
            try
            {
                var id = await _productTypeProcessor.UpdateProductType(productTypeRequest);
                return CreatedAtAction(nameof(GetAllProductTypeList), new { id = id, Controller = "ProductType" }, id);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

        }

    }
}
