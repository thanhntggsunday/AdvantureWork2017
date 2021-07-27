using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace AdvantureWork.DataService.Database.Dapper
{
    public static class DapperDbContextExtensions
    {
        public static async Task<IEnumerable<T>> QueryAsync<T>(
          this DbContext context,         
          string text,
          object parameters = null,
          int? timeout = null,
          CommandType? type = null
          
        )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type           
            );

            var connection = context.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public static async Task<int> ExecuteAsync(
            this DbContext context,         
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null
        )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type               
            );

            var connection = context.Database.GetDbConnection();
            return await connection.ExecuteAsync(command.Definition);
        }

        public static async Task<object> ExecuteScalarAsync(
           this DbContext context,
           string text,
           object parameters = null,
           int? timeout = null,
           CommandType? type = null
       )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type
            );

            var connection = context.Database.GetDbConnection();
            return await connection.ExecuteScalarAsync(command.Definition);
        }
    }
}