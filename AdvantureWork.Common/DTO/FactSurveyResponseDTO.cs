using System;

#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class FactSurveyResponseDTO
    {
        public int SurveyResponseKey { get; set; }
        public int DateKey { get; set; }
        public int CustomerKey { get; set; }
        public int ProductCategoryKey { get; set; }
        public string EnglishProductCategoryName { get; set; }
        public int ProductSubcategoryKey { get; set; }
        public string EnglishProductSubcategoryName { get; set; }
        public DateTime? Date { get; set; }
    }
}