using System;

#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class VTimeSeriesDTO
    {
        public string ModelRegion { get; set; }
        public int? TimeIndex { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public short CalendarYear { get; set; }
        public byte Month { get; set; }
        public DateTime? ReportingDate { get; set; }
    }
}