using System.ComponentModel.DataAnnotations;

namespace OYC_API.Response
{
    public class ProductTypeResponse
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    }
}
