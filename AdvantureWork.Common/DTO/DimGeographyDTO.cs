#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class DimGeographyDTO
    {
        public int GeographyKey { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string StateProvinceName { get; set; }
        public string CountryRegionCode { get; set; }
        public string EnglishCountryRegionName { get; set; }
        public string SpanishCountryRegionName { get; set; }
        public string FrenchCountryRegionName { get; set; }
        public string PostalCode { get; set; }
        public int? SalesTerritoryKey { get; set; }
        public string IpAddressLocator { get; set; }
    }
}