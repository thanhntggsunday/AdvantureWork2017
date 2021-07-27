namespace AdvantureWork.DataService.SQL
{
    public class CountryRegionScript
    {
        public const string GET_ALL_PAGING_COMMAND = @"SELECT  *
                            FROM    ( SELECT ROW_NUMBER() OVER ( ORDER BY CountryRegionCode ) AS RowNum, *
                                      FROM [CountryRegion]
                                      {0}
                                    ) AS RowConstrainedResult
                            WHERE   RowNum >= @StartIndex
                                    AND RowNum <= @EndIndex
                            ORDER BY [Name];
                            SELECT  @TotalRows = Count(*) From [CountryRegion] {0};";
    }
}