#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class DimProductSubcategoryDTO
    {
        public int ProductSubcategoryKey { get; set; }
        public int? ProductSubcategoryAlternateKey { get; set; }
        public string EnglishProductSubcategoryName { get; set; }
        public string SpanishProductSubcategoryName { get; set; }
        public string FrenchProductSubcategoryName { get; set; }
        public int? ProductCategoryKey { get; set; }
    }
}