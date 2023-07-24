using OYC_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace OYC_API.Response
{
    public class ProductResponse
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public List<ProductSize> ProductSize { get; set; }
        public string ProductPrice { get; set; }
        public string ProductSrc { get; set; }
        public string ProductFileName { get; set; }
        public IFormFile ProductFile { get; set; }
    }
}
