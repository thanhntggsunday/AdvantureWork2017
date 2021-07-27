namespace AdvantureWork.Common.Request
{
    public class DataTableRequest
    {
        public DataTableRequest()
        {
            Draw = "1";
            Start = "0";
            Length = "100";
            Search = "";
        }

        public string Draw { get; set; }
        public string Start { get; set; }
        public string Length { get; set; }
        public string Search { get; set; }
    }
}