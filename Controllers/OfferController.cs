using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OYC_API.Data;
using OYC_API.Entities;
using OYC_API.Request;

namespace OYC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        public readonly OycContext _context;
        public readonly IWebHostEnvironment _hostEnvironment;
        public OfferController(OycContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        [Route("GetOfferList")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetAllOfferList()
        {
            try
            {
                return await _context.Offer.Select(x => new Offer()
                {
                    OfferID = x.OfferID,
                    OfferType = x.OfferType,
                    ProductSrc = x.ProductFileName != null ? String.Format("{0}://{1}{2}/Image/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ProductFileName) : 
                    String.Format("{0}://{1}{2}/Image/{3}", Request.Scheme, Request.Host, Request.PathBase, "Product-162023384260.jpg"),
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
        [Route("AddOffer")]
        public async Task<IActionResult> AddOffer([FromForm] Offer offerRequest)
        {
            try
            {

                //var id = await _productProcessor.AddProduct(productRequest);
                if (offerRequest.ProductFile != null)
                {
                    offerRequest.ProductFileName = await SaveImage(offerRequest.ProductFile);
                }
                _context.Offer.Add(offerRequest);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteOffer")]
        public async Task<IActionResult> DeleteOffer([FromBody] DeleteOfferRequest deleteOfferRequest)
        {
            try
            {
                var offer = await _context.Offer.Where(a => a.OfferID == deleteOfferRequest.OfferID).FirstOrDefaultAsync();

                if (offer == null)
                {
                    return NotFound();
                }

                _context.Offer.RemoveRange(offer);
                var result = await _context.SaveChangesAsync();
                if (result == 0) return BadRequest(" delete error");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
            return Ok();

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
