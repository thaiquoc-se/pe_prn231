using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class SilverJewelryCreate
    {
        [Required]
        public string SilverJewelryId { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(?:[A-Z][a-z0-9]*)(?: [A-Z][a-z0-9]*)*$", ErrorMessage = "Invalid Silver Jewelry Name")]
        public string SilverJewelryName { get; set; } = default!;

        [Required]
        public string SilverJewelryDescription { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "MetalWeight must be greater than or equal to 0.")]
        public decimal MetalWeight { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0.")]
        public decimal Price { get; set; }

        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "Production year must be 1900 or later.")]
        public int ProductionYear { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CategoryId { get; set; } = null!;
    }
}
