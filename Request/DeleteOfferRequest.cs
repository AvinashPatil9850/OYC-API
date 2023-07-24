using System.ComponentModel.DataAnnotations;

namespace OYC_API.Request
{
    public class DeleteOfferRequest
    {
        [Key]
        public int OfferID { get; set; }
    }
}
