namespace AdvantureWork.Common.Request
{
    public class GetRolesPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}