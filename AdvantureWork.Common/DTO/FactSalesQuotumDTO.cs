using System;

#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class FactSalesQuotumDTO
    {
        public int SalesQuotaKey { get; set; }
        public int EmployeeKey { get; set; }
        public int DateKey { get; set; }
        public short CalendarYear { get; set; }
        public byte CalendarQuarter { get; set; }
        public decimal SalesAmountQuota { get; set; }
        public DateTime? Date { get; set; }
    }
}