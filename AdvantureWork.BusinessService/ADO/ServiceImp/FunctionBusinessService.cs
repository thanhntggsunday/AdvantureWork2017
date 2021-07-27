using AdvantureWork.Common.Constant;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.DataService.SQL;
using AdvantureWork.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AdvantureWork.BusinessService.ADO.ServiceImp
{
    public class FunctionBusinessService : BaseBusinessService
    {
        public DataTableViewModel<AppFunctionDTO> GetAll()
        {
            List<AppFunctionDTO> functions = new List<AppFunctionDTO>();
            var viewModel = new DataTableViewModel<AppFunctionDTO>();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = FunctionScript.GET_ALL_COMMAND;

                var result = DataAccess.LoadDataTable(sqlCommand);
                DataAccess.Dispose();

                var index = 0;
                while (index < result.Rows.Count)
                {
                    var item = new AppFunctionDTO();
                    item.CloneData(result, index);

                    functions.Add(item);

                    index++;
                }

                result.Dispose();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = functions.ToArray();
                viewModel.recordsTotal = functions.Count();
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return viewModel;
        }
    }
}