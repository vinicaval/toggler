using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Toggler.Core.Entity;

namespace Toggler.Core.Repository
{
    public class FeatureRepository : IRepository<Feature>
    {
        private readonly ConnectionOptions _connectionOptions;

        public FeatureRepository(ConnectionOptions connectionOptions)
        {
            _connectionOptions = connectionOptions;
        }

        public async Task<IEnumerable<Feature>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_connectionOptions.SQL_CONNECTION))
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT Id, Name, Description");
                sb.AppendLine("FROM Feature F");

                return await conn.QueryAsync<Feature>(sb.ToString());

            }
        }

        public async Task<IEnumerable<Feature>> GetAsync(Guid applicationId)
        {
            using (var conn = new SqlConnection(_connectionOptions.SQL_CONNECTION)) {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT Id, Name, Active");
                sb.AppendLine("FROM Feature F");
                sb.AppendLine("INNER JOIN ApplicationFeature AF on AF.IdFeature = F.Id");
                sb.AppendLine("WHERE AF.IdApplication = @applicationId");

                return await conn.QueryAsync<Feature>(sb.ToString(), new { applicationId });

            }
        }

        public async Task InsertAsync(Feature feature)
        {
            using (var conn = new SqlConnection(_connectionOptions.SQL_CONNECTION))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [Feature] (Name, Description)");
                sb.AppendLine("VALUES (@Name, @Description)");

                await conn.ExecuteAsync(sb.ToString(),feature);
            }
        }
    }
}
