using System;

#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class NewFactCurrencyRateDTO
    {
        public float? AverageRate { get; set; }
        public string CurrencyId { get; set; }
        public DateTime? CurrencyDate { get; set; }
        public float? EndOfDayRate { get; set; }
        public int? CurrencyKey { get; set; }
        public int? DateKey { get; set; }
    }
}