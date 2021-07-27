#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class DimProductCategoryDTO
    {
        public int ProductCategoryKey { get; set; }
        public int? ProductCategoryAlternateKey { get; set; }
        public string EnglishProductCategoryName { get; set; }
        public string SpanishProductCategoryName { get; set; }
        public string FrenchProductCategoryName { get; set; }
    }
}