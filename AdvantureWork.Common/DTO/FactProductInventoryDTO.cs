using System;

#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class FactProductInventoryDTO
    {
        public int ProductKey { get; set; }
        public int DateKey { get; set; }
        public DateTime MovementDate { get; set; }
        public decimal UnitCost { get; set; }
        public int UnitsIn { get; set; }
        public int UnitsOut { get; set; }
        public int UnitsBalance { get; set; }
    }
}