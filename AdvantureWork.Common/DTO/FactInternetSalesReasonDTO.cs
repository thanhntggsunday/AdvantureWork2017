#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class FactInternetSalesReasonDTO
    {
        public string SalesOrderNumber { get; set; }
        public byte SalesOrderLineNumber { get; set; }
        public int SalesReasonKey { get; set; }
    }
}