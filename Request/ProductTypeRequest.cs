using System.ComponentModel.DataAnnotations;

namespace OYC_API.Request
{
    public class ProductTypeRequest
    {
        [Key]
        public int ProductTypeId { get;set; }
        public string? ProductTypeName { get;set; }
    }
}
