using AdvantureWork.Common.DTO;
using AdvantureWork.Model.DTO;
using AdvantureWork.Model.Entities;
using System.Data;

namespace AdvantureWork.Common.Helper
{
    public static class TableDataReaderCloneExtensions
    {
        public static void CloneData(this AppLevelPermissionDTO itemDto, DataTable table, int rowIndex)
        {
            TableDataReader dataReader = new TableDataReader(table, rowIndex);

            itemDto.FunctionActionId = dataReader.GetInt32("FunctionActionId");
            itemDto.FunctionId = dataReader.GetString("FunctionId");
            itemDto.FunctionName = dataReader.GetString("FunctionName");
            itemDto.ActionId = dataReader.GetString("ActionId");
            itemDto.ActionName = dataReader.GetString("ActionName");

            dataReader.Dispose();
        }

        public static void CloneData(this AppActionDTO itemDto, DataTable table, int rowIndex)
        {
            TableDataReader dataReader = new TableDataReader(table, rowIndex);

            itemDto.ID = dataReader.GetString("ID");
            itemDto.Name = dataReader.GetString("Name");
            itemDto.Description = dataReader.GetString("Description");

            dataReader.Dispose();
        }

        public static void CloneData(this AppAllUserPermissionDTO itemDto, DataTable table, int rowIndex)
        {
            TableDataReader dataReader = new TableDataReader(table, rowIndex);

            itemDto.UserId = dataReader.GetString("UserId");
            itemDto.ActionId = dataReader.GetString("ActionId");
            itemDto.Email = dataReader.GetString("Email");
            itemDto.FunctionId = dataReader.GetString("FunctionId");
            itemDto.RoleId = dataReader.GetString("RoleId");
            itemDto.RoleName = dataReader.GetString("RoleName");
            itemDto.UserId = dataReader.GetString("UserId");

            dataReader.Dispose();
        }

        public static void CloneData(this DatabaseLogDTO itemDto, DataTable table, int rowIndex)
        {
            TableDataReader dataReader = new TableDataReader(table, rowIndex);

            itemDto.DatabaseLogId = dataReader.GetInt32("DatabaseLogID");
            itemDto.DatabaseUser = dataReader.GetString("DatabaseUser");
            itemDto.Event = dataReader.GetString("Event");
            itemDto.Object = dataReader.GetString("Object");
            itemDto.PostTime = dataReader.GetDateTime("PostTime");
            itemDto.Schema = dataReader.GetString("Schema");
            itemDto.Tsql = dataReader.GetString("TSQL");

            dataReader.Dispose();
        }

        public static void CloneData(this AppFunctionDTO itemDto, DataTable table, int rowIndex)
        {
            TableDataReader dataReader = new TableDataReader(table, rowIndex);

            itemDto.ID = dataReader.GetString("ID");
            itemDto.Name = dataReader.GetString("Name");
            itemDto.ParentId = dataReader.GetString("ParentId");
            itemDto.Status = dataReader.GetBoolean("Status");
            itemDto.URL = dataReader.GetString("URL");

            dataReader.Dispose();
        }

        public static void CloneData(this AppPermissionDTO itemDto, DataTable table, int rowIndex)
        {
            TableDataReader dataReader = new TableDataReader(table, rowIndex);

            itemDto.ID = dataReader.GetInt32("ID");
            itemDto.ActionId = dataReader.GetString("ActionId");
            itemDto.FunctionId = dataReader.GetString("FunctionId");
            itemDto.RoleId = dataReader.GetString("RoleId");
            itemDto.RoleName = dataReader.GetString("RoleName");

            dataReader.Dispose();
        }

        public static void CloneData(this CountryRegionDTO itemDto, DataTable table, int rowIndex = 0)
        {
            TableDataReader dataReader = new TableDataReader(table, rowIndex);

            itemDto.CountryRegionCode = dataReader.GetString("CountryRegionCode");
            itemDto.Name = dataReader.GetString("Name");
            itemDto.ModifiedDate = dataReader.GetDateTime("ModifiedDate");

            dataReader.Dispose();
        }



    }
}