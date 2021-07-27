#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class DimOrganizationDTO
    {
        public int OrganizationKey { get; set; }
        public int? ParentOrganizationKey { get; set; }
        public string PercentageOfOwnership { get; set; }
        public string OrganizationName { get; set; }
        public int? CurrencyKey { get; set; }
    }
}