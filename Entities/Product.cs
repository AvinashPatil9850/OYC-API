using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OYC_API.Entities
{
    public class Product
    {
        [Key]
        
        public int ProductID {get;set;}
        public string? ProductName {get;set;}
        public string? ProductType {get;set;}
        public List<ProductSize> ProductSize { get; set; }
        public string? ProductPrice {get;set; }
        [NotMapped]
        public string? ProductSrc { get; set; }
        public string? ProductFileName { get; set; }
        [NotMapped]
        public IFormFile? ProductFile { get; set; }
    }
}
