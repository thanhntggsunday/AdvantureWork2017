namespace AdvantureWork.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        
        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            ReturnStatus = false;
            ReturnMessage.Add(message);
        }

       
    }
}