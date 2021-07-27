using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.DataService.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AdvantureWork.BusinessService.ADO.ServiceImp
{
    public class LevelPermissionBusinessService : BaseBusinessService
    {
        public DataTableViewModel<AppLevelPermissionDTO> GetAll()
        {
            List<AppLevelPermissionDTO> levelPermissions = new List<AppLevelPermissionDTO>();
            var viewModel = new DataTableViewModel<AppLevelPermissionDTO>();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = LevePermissionScript.GET_ALL_COMMAND;

                var result = DataAccess.LoadDataTable(sqlCommand);
                DataAccess.Dispose();

                var index = 0;
                while (index < result.Rows.Count)
                {
                    var item = new AppLevelPermissionDTO();
                    item.CloneData(result, index);

                    levelPermissions.Add(item);

                    index++;
                }

                result.Dispose();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = levelPermissions.ToArray();
                viewModel.recordsTotal = levelPermissions.Count();
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return viewModel;
        }

        public DataTableViewModel<AppLevelPermissionDTO> GetActionsByFunctionId(string functionId)
        {
            List<AppLevelPermissionDTO> levelPermissions = new List<AppLevelPermissionDTO>();
            var viewModel = new DataTableViewModel<AppLevelPermissionDTO>();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = LevePermissionScript.GET_ALL_BY_FUNCTION_ID_COMMAND;
                SqlParameter parameter = new SqlParameter("@FunctionId", functionId);
                sqlCommand.Parameters.Add(parameter);

                var result = DataAccess.LoadDataTable(sqlCommand);
                DataAccess.Dispose();

                var index = 0;
                while (index < result.Rows.Count)
                {
                    var item = new AppLevelPermissionDTO();
                    item.CloneData(result, index);

                    levelPermissions.Add(item);

                    index++;
                }

                result.Dispose();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = levelPermissions.ToArray();
                viewModel.recordsTotal = levelPermissions.Count();
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