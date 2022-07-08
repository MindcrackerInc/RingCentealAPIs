using Microsoft.AspNetCore.Mvc;
using RingCentral.Reporting.Models.Interfaces;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Data.Repository.Interfaces;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncAllDataController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IDeleteRepo _deleteRepo;
        private readonly ISyncAllData _syncAllData;
        public SyncAllDataController(ILoggerManager logger, IConfiguration config
            ,IDeleteRepo deleteRepo
            , ISyncAllData syncAllData)
        {
            _configuration = config;
            _logger = logger;
            _deleteRepo = deleteRepo;
            _syncAllData = syncAllData;
        }
        [HttpPost]
        public async Task<IActionResult> Save()
        {
            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {
                SyncStatuts = await _deleteRepo.DeleteAllData();
             var response =  await  _syncAllData.CallAsync();
                if(response != null)
                {
                    return BadRequest(new SyncStatuts { IsCompleted = false, Message = "Error" });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new SyncStatuts { IsCompleted = false, Message = ex.Message });
            }
              return Ok(SyncStatuts);
            }
    }
}
