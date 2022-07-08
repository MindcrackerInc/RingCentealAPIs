using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RingCentral.Reporting.Data.Repository.Interfaces;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Models.IdentityGroup;
using RingCentral.Reporting.Models.Interfaces;
using System.Net.Http.Headers;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityGroupController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IIdentityGroupRepo _identityGroupRep;

        public IdentityGroupController(ILoggerManager logger, IConfiguration config, IIdentityGroupRepo identityGroupRep)
        {
            _configuration = config;
            _logger = logger;
            _identityGroupRep = identityGroupRep;
        }


        [HttpGet(Name = "SyncAllIdentityGroups")]
        public async Task<IActionResult> Get(int offSet=0,int limit=150)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {

                IdentityGroupModel IdentityGroup = new IdentityGroupModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/identity_groups?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        IdentityGroup = JsonConvert.DeserializeObject<IdentityGroupModel>(apiResponse);

                        if (IdentityGroup is not null && IdentityGroup.records is not null && IdentityGroup.records.Count > 0)
                        {
                            //SyncStatuts =  await _identityGroupRep.SyncIdentityGroup(JsonConvert.SerializeObject(IdentityGroup.records));
                            //SyncStatuts.Count = IdentityGroup.count;

                            int SavedRecords = await _identityGroupRep.CountAsync();
                            if (SavedRecords < IdentityGroup.count)
                            {
                                while (SavedRecords < IdentityGroup.count)
                                {
                                    int page = SavedRecords > 0 ? SavedRecords / limit : 0;
                                    if (SavedRecords > 0 && IdentityGroup.count - SavedRecords < limit)
                                    {
                                        limit = (int)IdentityGroup.count - SavedRecords;
                                    }
                                    await Save(page, limit);
                                    SavedRecords = await _identityGroupRep.CountAsync();
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

                IdentityGroupModel IdentityGroup = new IdentityGroupModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/identity_groups?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        IdentityGroup = JsonConvert.DeserializeObject<IdentityGroupModel>(apiResponse);

                        if (IdentityGroup is not null && IdentityGroup.records is not null && IdentityGroup.records.Count > 0)
                        {
                            SyncStatuts = await _identityGroupRep.SyncIdentityGroup(JsonConvert.SerializeObject(IdentityGroup.records));
                            SyncStatuts.Count = IdentityGroup.count;

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
