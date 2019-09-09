using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toggler.Core.Entity;
using Toggler.Core.Repository.Builder;

namespace Toggler.Core.Repository
{
    public class FeatureRepository : IRepository<Feature>
    {
        private readonly ConnectionOptions _connectionOptions;
        private readonly ApplicationFeatureBuilder _builder;

        public FeatureRepository(ConnectionOptions connectionOptions, ApplicationFeatureBuilder builder)
        {
            _connectionOptions = connectionOptions;
            _builder = builder;
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

        public async Task<IEnumerable<ApplicationFeature>> GetByApplicationIdAsync(Guid applicationId)
        {
            using (var conn = new SqlConnection(_connectionOptions.SQL_CONNECTION)) {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT A.Id as IDApplication, A.Name as NameApplication, A.Url as UrlApplication, AF.Active AS Active, F.Id as IdFeature, F.Name as NameFeature, F.Description as DescriptionFeature");
                sb.AppendLine("FROM Feature F");
                sb.AppendLine("INNER JOIN ApplicationFeature AF on AF.IdFeature = F.Id");
                sb.AppendLine("INNER JOIN Application A on AF.IdApplication = A.Id");
                sb.AppendLine("WHERE AF.IdApplication = @applicationId");

                var appFeatures = await conn.QueryAsync<ApplicationFeatureDto>(sb.ToString(), new { applicationId });

                return appFeatures.Count() > 0 ? _builder.Build(appFeatures) : null;
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
