namespace AdvantureWork.Model.DTO
{
    public partial class AppFunctionDTO
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }
        public int DisplayOrder { get; set; }
        public string ParentId { get; set; }
        public bool Status { get; set; }
        public string IconCss { get; set; }
    }
}