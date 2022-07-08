using RingCentral.Reporting.Models;

namespace RingCentral.Reporting.Data.Repository.Interfaces
{
    public interface IUserRepo
    {
        public Task<UserInfo> SignIn(string email, string password);
    }
}
