using System;

#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class FactCurrencyRateDTO
    {
        public int CurrencyKey { get; set; }
        public int DateKey { get; set; }
        public double AverageRate { get; set; }
        public double EndOfDayRate { get; set; }
        public DateTime? Date { get; set; }
    }
}