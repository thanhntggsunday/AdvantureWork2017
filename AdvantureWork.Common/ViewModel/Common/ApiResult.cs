using AdvantureWork.Common.Helper;
using System;
using System.Collections.Generic;

namespace AdvantureWork.ViewModels.Common
{
    public class ApiResult<T> : TransactionalInformation
    {
        public ApiResult()
        {
           
        }
     
        public T ResultObj { get; set; }
    }
}