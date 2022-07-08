using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RingCentral.Reporting.Data.Repository.Interfaces;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Models.Identities;
using RingCentral.Reporting.Models.Interfaces;
using System.Net.Http.Headers;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentitiesController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IIdentitiesRepo _identitiesRep;

        public IdentitiesController(ILoggerManager logger, IConfiguration config, IIdentitiesRepo identitiesRep)
        {
            _configuration = config;
            _logger = logger;
            _identitiesRep = identitiesRep;
        }


        [HttpGet(Name = "SyncAllIdentities")]
        public async Task<IActionResult> Get(int offSet=0,int limit=150)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {

                IdentitiesModel Identities = new IdentitiesModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/identities?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Identities = JsonConvert.DeserializeObject<IdentitiesModel>(apiResponse);

                        if (Identities is not null && Identities.records is not null && Identities.records.Count > 0)
                        {
                            //SyncStatuts =  await _identitiesRep.SyncIdentities(JsonConvert.SerializeObject(Identities.records));
                            //SyncStatuts.Count = Identities.count;
                            int SavedRecords = await _identitiesRep.CountAsync();
                            if (SavedRecords < Identities.count)
                            {
                                while (SavedRecords < Identities.count)
                                {
                                    int page = SavedRecords > 0 ? SavedRecords / limit : 0;
                                    if (SavedRecords > 0 && Identities.count - SavedRecords < limit)
                                    {
                                        limit = (int)Identities.count - SavedRecords;
                                    }
                                    await Save(page, limit);
                                    SavedRecords = await _identitiesRep.CountAsync();
                                }
                            }
                            else
                            {
                                return Ok(SyncStatuts);
                            }

                        }
                    }
                }
                return Ok(SyncStatuts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new SyncStatuts { IsCompleted = false, Message = ex.Message });
            }
        }

        [HttpGet("{offset}/{limit}")]
        public async Task<IActionResult> Save(int offSet = 0, int limit = 30)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {

                IdentitiesModel Identities = new IdentitiesModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/identities?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Identities = JsonConvert.DeserializeObject<IdentitiesModel>(apiResponse);

                        if (Identities is not null && Identities.records is not null && Identities.records.Count > 0)
                        {
                            SyncStatuts = await _identitiesRep.SyncIdentities(JsonConvert.SerializeObject(Identities.records));
                            SyncStatuts.Count = Identities.count;

                        }
                    }
                }
                return Ok(SyncStatuts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new SyncStatuts { IsCompleted = false, Message = ex.Message });
            }
        }
    }
}
