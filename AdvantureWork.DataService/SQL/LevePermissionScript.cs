namespace AdvantureWork.DataService.SQL
{
    public static class LevePermissionScript
    {
        public const string GET_ALL_COMMAND = @"SELECT * FROM V_LEVEL_PERMISSION";
        public const string GET_ALL_BY_FUNCTION_ID_COMMAND = @"SELECT * FROM V_LEVEL_PERMISSION WHERE FunctionId = @FunctionId";
    }
}