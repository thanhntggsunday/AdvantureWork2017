using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;

namespace AdvantureWork.Portal.Services.Interfaces
{
    public interface ILookupApiClient
    {
        DataTableViewModel<CountryRegionDTO> GetAllPaging(CountryListRequest request);
    }
}