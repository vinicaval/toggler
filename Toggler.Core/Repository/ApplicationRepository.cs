using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Toggler.Core.Entity;

namespace Toggler.Core.Repository
{
    public class ApplicationRepository : IRepository<Application>
    {
        private readonly ConnectionOptions _connectionOptions;

        public ApplicationRepository(ConnectionOptions connectionOptions)
        {
            _connectionOptions = connectionOptions;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_connectionOptions.SQL_CONNECTION))
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT Id, Name, Url");
                sb.AppendLine("FROM Application");

                return await conn.QueryAsync<Application>(sb.ToString());

            }
        }

        public async Task InsertAsync(Application application)
        {
            using (var conn = new SqlConnection(_connectionOptions.SQL_CONNECTION))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [Application] (Name, Url)");
                sb.AppendLine("VALUES (@Name, @Url)");

                await conn.ExecuteAsync(sb.ToString(), application);

            }

        }
    }
}
