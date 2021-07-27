using AdvantureWork.Model.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdvantureWork.DataService.ADO
{
    public static class ExtensionToSqlParameters
    {
        #region Role_Permission

        private static SqlParameter[] ToSqlParametersForObjectNoId(AppRole_Permission item)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter("@RoleID", item.RoleID),
                new SqlParameter("@Function_ActionID", item.Function_ActionID)
            };

            return param;
        }

        public static SqlParameter[] ToSqlParametersForInsert(this AppRole_Permission item)
        {
            var parambase = ToSqlParametersForObjectNoId(item);
            var paramOutput = new SqlParameter("@ID", SqlDbType.Int);
            paramOutput.Direction = ParameterDirection.Output;

            SqlParameter[] param = new SqlParameter[parambase.Length + 1];
            parambase.CopyTo(param, 0);
            param[param.Length - 1] = paramOutput;

            return param;
        }

        public static SqlParameter[] ToSqlParametersForUpdate(this AppRole_Permission item)
        {
            var parambase = ToSqlParametersForObjectNoId(item);

            SqlParameter[] param = new SqlParameter[parambase.Length + 1];
            parambase.CopyTo(param, 0);
            param[param.Length - 1] = new SqlParameter("@ID", item.ID);

            return param;
        }

        #endregion Role_Permission
    }
}