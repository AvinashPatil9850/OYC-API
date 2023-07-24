using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OYC_API.Entities
{
    public class Offer
    {
        [Key]
        public int OfferID { get; set; }
        public string? OfferType { get; set; }
        [NotMapped]
        public string? ProductSrc { get; set; }
        public string? ProductFileName { get; set; }
        [NotMapped]
        public IFormFile? ProductFile { get; set; }
    }
}
