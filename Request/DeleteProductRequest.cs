using System.ComponentModel.DataAnnotations;

namespace OYC_API.Request
{
    public class DeleteProductRequest
    {
        [Key]
        public int ProductID { get; set; }
    }
}
