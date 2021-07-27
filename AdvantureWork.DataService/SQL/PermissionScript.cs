namespace AdvantureWork.DataService.SQL
{
    public static class PermissionScript
    {
        public const string GET_ALL_PAGING_COMMAND = @"SELECT  *
                            FROM    ( SELECT ROW_NUMBER() OVER ( ORDER BY RoleName ) AS RowNum, *
                                      FROM [V_ALL_ROLE_PERMISSION]
                                      {0}
                                    ) AS RowConstrainedResult
                            WHERE   RowNum >= @StartIndex
                                    AND RowNum <= @EndIndex
                            ORDER BY RoleName;
                            SELECT  @TotalRows = Count(*) From [V_ALL_ROLE_PERMISSION] {0};";

        public const string GET_ALL_USER_PERMISSION_BY_USER_ID = @"SELECT *  FROM [V_ALL_USER_ROLE_PERMISSION] WHERE  Email = @UserId;";

        public const string INSERT_INTO_ROLE_PERMISSION = @"INSERT INTO [dbo].[AppRole_Permission]
                                                           ([RoleID]
                                                           ,[Function_ActionID])
                                                     VALUES
                                                           (@RoleID, @Function_ActionID);
                                                    SELECT  @ID = SCOPE_IDENTITY();";

        public const string REMOVE_All_ROLE_PERMISSION_OF_ROLE = @"DELETE FROM [AppRole_Permission] WHERE RoleID = @RoleID AND Function_ActionID = @Function_ActionID";
    }
}