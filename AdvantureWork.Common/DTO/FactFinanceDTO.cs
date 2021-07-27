using System;

#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class FactFinanceDTO
    {
        public int FinanceKey { get; set; }
        public int DateKey { get; set; }
        public int OrganizationKey { get; set; }
        public int DepartmentGroupKey { get; set; }
        public int ScenarioKey { get; set; }
        public int AccountKey { get; set; }
        public double Amount { get; set; }
        public DateTime? Date { get; set; }
    }
}