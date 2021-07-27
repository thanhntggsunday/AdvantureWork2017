using AdvantureWork.BusinessService.ADO.Interface;
using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.DataService.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdvantureWork.BusinessService.ADO.ServiceImp
{
    public class CountryRegionBusinessService : BaseBusinessService, ICountryRegionBusinessService
    {
        public DataTableViewModel<CountryRegionDTO> GetAllPaging(int pageNo, string search = "")
        {
            int pageSize = 5;
            long startIndex = 0;
            long endIndex = 0;

            if (search == null)
            {
                search = "";
            }

            DataTableViewModel<CountryRegionDTO> viewModel = new DataTableViewModel<CountryRegionDTO>();
            var countryDtos = new List<CountryRegionDTO>();
            int totalRows = 0;

            startIndex = (pageNo - 1) * pageSize;
            endIndex = startIndex + pageSize - 1;

            try
            {
                var paramOutput = new SqlParameter("@TotalRows", SqlDbType.Int);
                paramOutput.Direction = ParameterDirection.Output;

                var arrParam = new SqlParameter[]
                {
                    new SqlParameter("@StartIndex", startIndex + 1),
                    new SqlParameter("@EndIndex", endIndex + 1),
                    paramOutput
                };
                string sqlQuery = CountryRegionScript.GET_ALL_PAGING_COMMAND;
                string strWhere = "";

                if (!string.IsNullOrEmpty(search))
                {
                    search = "%" + search + "%";
                    strWhere = " WHERE Name LIKE '" + search + "'";
                }
                sqlQuery = sqlQuery.Replace("{0}", strWhere);


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddRange(arrParam);

                var dtresult = DataAccess.LoadDataTable(sqlCommand);

                var index = 0;
                while (index < dtresult.Rows.Count)
                {
                    var item = new CountryRegionDTO();
                    item.CloneData(dtresult, index);

                    countryDtos.Add(item);

                    index++;
                }

                totalRows = (int)paramOutput.Value;
                dtresult.Dispose();
                DataAccess.Dispose();

                viewModel.data = countryDtos.ToArray();
                viewModel.pagesTotal = (totalRows / pageSize) + ((totalRows % pageSize) > 0 ? 1 : 0);

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
            }
            catch (Exception ex)
            {
               
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }
            return viewModel;
        }
    }
}
