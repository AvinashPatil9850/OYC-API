using System.ComponentModel.DataAnnotations;

namespace OYC_API.Entities
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    }
}
    