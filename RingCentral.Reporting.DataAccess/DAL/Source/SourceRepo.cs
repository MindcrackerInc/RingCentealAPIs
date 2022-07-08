using Dapper;
using Microsoft.Extensions.Configuration;
using RingCentral.Reporting.Data.Repository.Interfaces;
using RingCentral.Reporting.Data.Repository;
using RingCentral.Reporting.Models;
using System.Data;
using System.Data.SqlClient;

namespace RingCentral.Reporting.Data.Repository
{
    public class SourceRepo: ISourceRepo
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ILogRepo _logRepo;

        public SourceRepo(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DBConnectionString");
            _logRepo = new LogRepo(config);
        }

        public async Task<SyncStatuts> SyncSource(string SourceJson)
        {
            SyncStatuts status = new SyncStatuts();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "Sync_Sources";
                    var values = new { Json = SourceJson };
                    status = await connection.QueryFirstOrDefaultAsync<SyncStatuts>(procedure, values, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                //await _logRepo.Log(LogTypeEnum.Error.ToString(), $"{ex.Message}\n{ex.StackTrace}", LogModuleEnum.User.ToString());
            }
            return status;
        }
        public async Task<int> CountAsync()
        {
            int count = 0;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "select count(*) from Sources";
                    count = await connection.ExecuteScalarAsync<int>(query);
                }
            }
            catch (Exception ex)
            {
                //await _logRepo.Log(LogTypeEnum.Error.ToString(), $"{ex.Message}\n{ex.StackTrace}", LogModuleEnum.User.ToString());
            }
            return count;
        }
    }
}
