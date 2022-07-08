using RingCentral.Reporting.Models;

namespace RingCentral.Reporting.Data.Repository.Interfaces
{
    public interface IIdentitiesRepo:IgetCount
    {
        public Task<SyncStatuts> SyncIdentities(string identitiesJson);
    }
}
