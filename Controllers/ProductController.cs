using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using OYC_API.Data;
using OYC_API.Entities;
using OYC_API.Interface;
using OYC_API.Request;

namespace OYC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductProcessor _productProcessor;
        public readonly OycContext _context;
        public readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IProductProcessor productProcessor, OycContext context, IWebHostEnvironment hostEnvironment)
        {
            _productProcessor = productProcessor;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        [Route("GetProductList")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductList()
        {
            try
            {
                return await _context.Product.Select(x => new Product()
                {
                    ProductID = x.ProductID,
                    ProductFileName = x.ProductFileName,
                    ProductPrice = x.ProductPrice,
                    ProductName = x.ProductName,
                    ProductSrc = x.ProductFileName != null? String.Format("{0}://{1}{2}/Image/{3}",Request.Scheme, Request.Host, Request.PathBase,x.ProductFileName):
                    String.Format("{0}://{1}{2}/Image/{3}", Request.Scheme, Request.Host, Request.PathBase, "Product-162023384260.jpg"),
                    ProductSize = x.ProductSize,
                    ProductType = x.ProductType,
                }).ToListAsync();

                //var response = await _productProcessor.GetAllProductList();
                //return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] Product productRequest)
        {
            try
            {
                
                //var id = await _productProcessor.AddProduct(productRequest);
                if (productRequest.ProductFile != null)
                {
                    productRequest.ProductFileName = await SaveImage(productRequest.ProductFile);
                }
                _context.Product.Add(productRequest);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequest productRequest)
        {
            try
            {
                var id = await _productProcessor.DeleteProduct(productRequest);
                return CreatedAtAction(nameof(GetAllProductList), new { id = id, Controller = "Product" }, id);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

        }
        [HttpPut]
        [Route("UpdateProduct")]

        public async Task UpdateProduct([FromForm] Product productRequest)
        {
            var product = _context.Product.Include(p => p.ProductSize).FirstOrDefault(p => p.ProductID == productRequest.ProductID);
            if (product != null)
            {
                if (productRequest.ProductFile != null)
                {
                    DeleteImage(productRequest.ProductFileName);
                    productRequest.ProductFileName = await SaveImage(productRequest.ProductFile);
                }
                product.ProductType = productRequest.ProductType;
                product.ProductName = productRequest.ProductName;
                product.ProductPrice = productRequest.ProductPrice;
                product.ProductSrc = productRequest.ProductSrc;
                product.ProductSize = productRequest.ProductSize;
                product.ProductFileName = productRequest.ProductFileName;

                await _context.SaveChangesAsync();
            }
             //   _context.Entry(productRequest).State = EntityState.Modified;
            //foreach (var sizes in productRequest.ProductSize)
            //{
            //    parent.ProductSize.ForEach(x =>
            //    {
            //        x.Name = sizes.Name;
            //    });
            //}


            //foreach (var sizes in productRequest.ProductSize)
            //{
            //    ProductSize destinationEntity = new ProductSize
            //    {
            //      Name= sizes.Name
            //    };

            //    parent.ProductSize.Add(destinationEntity);
            //}

            //await _context.SaveChangesAsync();

            //if (productRequest.ProductID == 0)
            //{
            //    return BadRequest();
            //}
            //_context.Entry(productRequest).State = EntityState.Modified;
            ////_context.Entry(productRequest.ProductSize).State = EntityState.Modified;
            //if (productRequest.ProductFile != null)
            //{
            //    DeleteImage(productRequest.ProductFileName);
            //    productRequest.ProductFileName = await SaveImage(productRequest.ProductFile);

            //}
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    // return this.StatusCode(500, ex.Message);
            //}
            //return NoContent();
            //try
            //{
            //    //var foo = _context.Product.Include("ProductSizeTable").Where(i => i.ProductID == productRequest.ProductID).FirstOrDefault();

            //    //foreach (var bar in foo.ProductSize)
            //    //{
            //    //    bar = productRequest.ProductSize;
            //    //}

            //    //_context.SaveChanges();


            //    var product = await _context.Product.FindAsync(productRequest.ProductID);
            //    if (product != null)
            //    {
            //        if (productRequest.ProductFile != null)
            //        {
            //            DeleteImage(productRequest.ProductFileName);
            //            productRequest.ProductFileName = await SaveImage(productRequest.ProductFile);
            //        }
            //        product.ProductType = productRequest.ProductType;
            //        product.ProductName = productRequest.ProductName;
            //        product.ProductPrice = productRequest.ProductPrice;
            //        product.ProductSrc = productRequest.ProductSrc;
            //        //var size = await _context.ProductSizeTable.FindAsync(productRequest.ProductID);
            //        //{
            //        //    productRequest.ProductSize.ForEach((ele:any) =>
            //        //    {
            //        //        size.Name=ele
            //        //    }
            //        //    );
            //        //}
            //        product.ProductSize = productRequest.ProductSize;
            //        product.ProductFileName = productRequest.ProductFileName;

            //        await _context.SaveChangesAsync();
            //    }

            //}
            //catch (Exception ex)
            //{

            //}

        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yyyymmssff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Image", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Image", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

    }
    
}
