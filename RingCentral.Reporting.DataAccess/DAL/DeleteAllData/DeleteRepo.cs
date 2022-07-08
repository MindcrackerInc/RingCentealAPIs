using Dapper;
using Microsoft.Extensions.Configuration;
using RingCentral.Reporting.Data.Repository.Interfaces;
using RingCentral.Reporting.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Data.Repository.DAL.DeleteAllData
{
    public class DeleteRepo:IDeleteRepo
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public DeleteRepo(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DBConnectionString");
        }
        public async Task<SyncStatuts> DeleteAllData()
        {
            SyncStatuts status = new SyncStatuts();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "DeleteAllData";
                    status = await connection.QueryFirstOrDefaultAsync<SyncStatuts>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                //await _logRepo.Log(LogTypeEnum.Error.ToString(), $"{ex.Message}\n{ex.StackTrace}", LogModuleEnum.User.ToString());
            }
            return status;
        }
    }
}
