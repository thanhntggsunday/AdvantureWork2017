namespace AdvantureWork.DataService.SQL
{
    public class DatabaseLogScripts
    {
        public const string GET_ALL_PAGING_COMMAND = @"SELECT  *
                            FROM    ( SELECT ROW_NUMBER() OVER ( ORDER BY DatabaseLogID ) AS RowNum, *
                                      FROM [DatabaseLog]
                                      {0}
                                    ) AS RowConstrainedResult
                            WHERE   RowNum >= @StartIndex
                                    AND RowNum <= @EndIndex
                            ORDER BY [Name];
                            SELECT  @TotalRows = Count(*) From [DatabaseLog] {0};";

        public const string GET_ALL_COMMAND = @"SELECT  * FROM [DatabaseLog];  SELECT  @TotalRows = Count(*) From [DatabaseLog];";
    }
}