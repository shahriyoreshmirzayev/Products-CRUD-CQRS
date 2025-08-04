using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class UpdateProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mahsulot nomi kiritilishi shart")]
        [StringLength(100, ErrorMessage = "Mahsulot nomi 100 ta belgidan oshmasligi kerak")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Tavsif 500 ta belgidan oshmasligi kerak")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Narx kiritilishi shart")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Narx 0 dan katta bo'lishi kerak")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Soni kiritilishi shart")]
        [Range(0, int.MaxValue, ErrorMessage = "Soni 0 dan kichik bo'lmasligi kerak")]
        public int Stock { get; set; }
    }
}
