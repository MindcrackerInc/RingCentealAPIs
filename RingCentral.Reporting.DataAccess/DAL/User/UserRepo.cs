using Dapper;
using Microsoft.Extensions.Configuration;
using RingCentral.Reporting.Data.Repository.Interfaces;
using RingCentral.Reporting.Models;
using System.Data;
using System.Data.SqlClient;

namespace RingCentral.Reporting.Data.Repository
{
    public class UserRepo:IUserRepo   
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ILogRepo _logRepo;

        public UserRepo(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DBConnectionString");
            _logRepo = new LogRepo(config);
        }

        public async Task<UserInfo> SignIn(string email, string password)
        {
            UserInfo user = null;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "UserSignIn";
                    var values = new { Email = email, Password = password };
                    user = await connection.QueryFirstOrDefaultAsync<UserInfo>(procedure, values, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                //await _logRepo.Log(LogTypeEnum.Error.ToString(), $"{ex.Message}\n{ex.StackTrace}", LogModuleEnum.User.ToString());
            }
            return user;
        }
    }
}
