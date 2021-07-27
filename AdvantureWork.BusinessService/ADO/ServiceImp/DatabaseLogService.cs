using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.DataService.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdvantureWork.BusinessService.ADO.ServiceImp
{
    public class DatabaseLogService : BaseBusinessService
    {
        public DataTableViewModel<DatabaseLogDTO> GetAllDataLogs()
        {
            DataTableViewModel<DatabaseLogDTO> viewModel = new DataTableViewModel<DatabaseLogDTO>();
            try
            {
                var databaseLogs = new List<DatabaseLogDTO>();
                var paramOutput = new SqlParameter("@TotalRows", SqlDbType.Int);
                paramOutput.Direction = ParameterDirection.Output;

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = DatabaseLogScripts.GET_ALL_COMMAND;
                sqlCommand.Parameters.Add(paramOutput);

                var result = DataAccess.LoadDataTable(sqlCommand);
                DataAccess.Dispose();

                var index = 0;
                while (index < result.Rows.Count)
                {
                    var item = new DatabaseLogDTO();
                    item.CloneData(result, index);

                    databaseLogs.Add(item);

                    index++;
                }

                result.Dispose();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = databaseLogs.ToArray();
                viewModel.recordsTotal = long.Parse(paramOutput.Value.ToString());

                return viewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                DataAccess.Dispose();

                return viewModel;
            }
        }
    }
}