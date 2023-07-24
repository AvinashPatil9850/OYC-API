using System.ComponentModel.DataAnnotations;

namespace OYC_API.Entities
{
    public class ProductSize
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
    }
}
