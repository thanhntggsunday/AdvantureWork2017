using AdvantureWork.Common.Helper;
using AdvantureWork.DataService.ADO;

namespace AdvantureWork.BusinessService.ADO.ServiceImp
{
    public class BaseBusinessService : BaseClass
    {
        private DataAccess _dataAccess;

        public DataAccess DataAccess
        {
            get
            {
                if (_dataAccess == null)
                {
                    _dataAccess = new DataAccess();
                }
                return _dataAccess;
            }
        }

        public new void Dispose()
        {
            if (_dataAccess != null)
            {
                _dataAccess.Dispose();
            }

            base.Dispose();
        }
    }
}