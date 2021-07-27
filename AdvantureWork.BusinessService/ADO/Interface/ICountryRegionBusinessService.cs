using AdvantureWork.Common.DTO;
using AdvantureWork.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantureWork.BusinessService.ADO.Interface
{
    public interface ICountryRegionBusinessService
    {
        DataTableViewModel<CountryRegionDTO> GetAllPaging(int pageNo, string countryName = "");
        void Dispose();
    }
}
