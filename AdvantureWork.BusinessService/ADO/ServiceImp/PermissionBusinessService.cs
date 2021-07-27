using AdvantureWork.BusinessService.Class;
using AdvantureWork.Common.Constant;
using AdvantureWork.Common.DTO;
using AdvantureWork.Common.Helper;
using AdvantureWork.Common.Request;
using AdvantureWork.Common.ViewModel;
using AdvantureWork.DataService.ADO;
using AdvantureWork.DataService.SQL;
using AdvantureWork.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdvantureWork.BusinessService.ADO.ServiceImp
{
    public class PermissionBusinessService : BaseBusinessService
    {
       
        public DataTableViewModel<AppPermissionDTO> GetAllPermissions()
        {
            var viewModel = new DataTableViewModel<AppPermissionDTO>();
            var items = new List<AppPermissionDTO>();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = PermissionScript.GET_ALL_PAGING_COMMAND;

                var result = DataAccess.LoadDataTable(sqlCommand);
                DataAccess.Dispose();

                var index = 0;
                while (index < result.Rows.Count)
                {
                    var item = new AppPermissionDTO();
                    item.CloneData(result, index);

                    items.Add(item);

                    index++;
                }

                result.Dispose();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = items.ToArray();
                viewModel.recordsTotal = items.Count();
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return viewModel;
        }

        public DataTableViewModel<AppPermissionDTO> GetAllPaging(DataTableRequest request)
        {
            var viewModel = new DataTableViewModel<AppPermissionDTO>();
            var items = new List<AppPermissionDTO>();

            try
            {
                int pageSize = Convert.ToInt32(request.Length);
                int startIndex = Convert.ToInt32(request.Start);
                int intDraw = Convert.ToInt32(request.Draw);
                int endIndex = startIndex + pageSize - 1;
                int totalRows = 0;

                var paramOutput = new SqlParameter("@TotalRows", SqlDbType.Int);
                paramOutput.Direction = ParameterDirection.Output;

                var arrParam = new SqlParameter[]
                {
                    new SqlParameter("@StartIndex", startIndex + 1),
                    new SqlParameter("@EndIndex", endIndex + 1),
                    paramOutput
                };
                string sqlQuery = PermissionScript.GET_ALL_PAGING_COMMAND;
                string strWhere = "";

                if (!string.IsNullOrEmpty(request.Search))
                {
                    request.Search = "%" + request.Search + "%";
                    strWhere = " WHERE RoleName LIKE '" + request.Search + "' OR FunctionId LIKE '" + request.Search + "' OR ActionId LIKE '" + request.Search + "'";
                }
                sqlQuery = sqlQuery.Replace("{0}", strWhere);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddRange(arrParam);

                var result = DataAccess.LoadDataTable(sqlCommand);
                DataAccess.Dispose();

                var index = 0;
                while (index < result.Rows.Count)
                {
                    var item = new AppPermissionDTO();
                    item.CloneData(result, index);

                    items.Add(item);

                    index++;
                }

                result.Dispose();

                totalRows = (int)paramOutput.Value;

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = items.ToArray();

                viewModel.draw = intDraw;
                viewModel.recordsFiltered = totalRows;
                viewModel.recordsTotal = totalRows;
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }
            return viewModel;
        }

        public void Insert(AppRole_Permission permission, out TransactionalInformation transactional)
        {
            transactional = new TransactionalInformation();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = PermissionScript.INSERT_INTO_ROLE_PERMISSION;

                SqlParameter[] parameters = permission.ToSqlParametersForInsert();
                sqlCommand.Parameters.AddRange(parameters);

                var id = DataAccess.ExecuteScalar(sqlCommand);

                DataAccess.Dispose();

                transactional.ReturnStatus = true;
                transactional.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
            }
            catch (Exception ex)
            {
                transactional.ReturnStatus = false;
                transactional.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void BulkInsert(List<AppRole_Permission> permissions, string[] arrRolesId, string[] arrFunctionActionId, out TransactionalInformation transactional)
        {
            transactional = new TransactionalInformation();
            try
            {
                DataAccess.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();

                //Remove permission
                for (int i = 0; i < arrRolesId.Length; i++)
                {
                    var roleId = arrRolesId[i];
                    for (int j = 0; j < arrFunctionActionId.Length; j++)
                    {
                        // Remove permission
                        sqlCommand.CommandText = PermissionScript.REMOVE_All_ROLE_PERMISSION_OF_ROLE;
                        var functionActionId = Int32.Parse(arrFunctionActionId[j]);
                        SqlParameter[] parametersDelete = new SqlParameter[]
                        {
                        new SqlParameter("@RoleID", roleId),
                        new SqlParameter("@Function_ActionID", functionActionId)
                        };

                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddRange(parametersDelete);

                        DataAccess.ExecuteNonQuery(sqlCommand);
                    }
                }

                for (int i = 0; i < permissions.Count; i++)
                {
                    var item = permissions[i];
                    if (!string.IsNullOrEmpty(item.RoleID))
                    {
                        SqlParameter[] parameters = item.ToSqlParametersForInsert();

                        // Add permission
                        sqlCommand.CommandText = PermissionScript.INSERT_INTO_ROLE_PERMISSION;
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddRange(parameters);

                        var id = DataAccess.ExecuteScalar(sqlCommand);
                    }
                }

                DataAccess.CommitTransaction();
                DataAccess.Dispose();

                transactional.ReturnStatus = true;
                transactional.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
            }
            catch (Exception ex)
            {
                transactional.ReturnStatus = false;
                transactional.ReturnMessage.Add(ex.Message);
                DataAccess.RollbackTransaction();
                DataAccess.Dispose();
                Console.WriteLine(ex.Message);
            }
        }

        public DataTableViewModel<AppAllUserPermissionDTO> GetAllUserPermissionsByUserId(string userId)
        {
            var viewModel = new DataTableViewModel<AppAllUserPermissionDTO>();
            var lstUserPermises = new List<AppAllUserPermissionDTO>();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                SqlParameter parameter = new SqlParameter("@UserId", userId);

                sqlCommand.CommandText = PermissionScript.GET_ALL_USER_PERMISSION_BY_USER_ID;
                sqlCommand.Parameters.Add(parameter);

                var result = DataAccess.LoadDataTable(sqlCommand);
                DataAccess.Dispose();

                var index = 0;
                while (index < result.Rows.Count)
                {
                    var item = new AppAllUserPermissionDTO();
                    item.CloneData(result, index);

                    lstUserPermises.Add(item);

                    index++;
                }

                result.Dispose();

                viewModel.ReturnStatus = true;
                viewModel.ReturnMessage.Add(MessagesConstant.SUCCESS_MESAGE);
                viewModel.data = lstUserPermises.ToArray();
                viewModel.recordsTotal = lstUserPermises.Count();

                return viewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }

            return viewModel;
        }


      

    }
}