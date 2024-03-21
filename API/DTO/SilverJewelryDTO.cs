namespace API.DTO
{
    public class SilverJewelryDTO
    {
        public string SilverJewelryId { get; set; } = null!;
        public string SilverJewelryName { get; set; } = null!;
        public string? SilverJewelryDescription { get; set; }
        public decimal? MetalWeight { get; set; }
        public decimal? Price { get; set; }
        public int? ProductionYear { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CategoryName { get; set; }
    }
}
