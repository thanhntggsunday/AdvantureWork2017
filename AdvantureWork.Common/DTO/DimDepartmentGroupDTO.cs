#nullable disable

namespace AdvantureWork.Common.DTO
{
    public partial class DimDepartmentGroupDTO
    {
        public int DepartmentGroupKey { get; set; }
        public int? ParentDepartmentGroupKey { get; set; }
        public string DepartmentGroupName { get; set; }
    }
}