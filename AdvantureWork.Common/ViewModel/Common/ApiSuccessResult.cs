namespace AdvantureWork.ViewModels.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObj)
        {
            ReturnStatus = true;
            ResultObj = resultObj;
        }

        public ApiSuccessResult()
        {
            ReturnStatus = true;
        }
    }
}