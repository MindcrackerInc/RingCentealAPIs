using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RingCentral.Reporting.Data.Repository;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Models.Interfaces;
using RingCentral.Reporting.Data.Repository.Interfaces;
using System.Net.Http.Headers;
using RingCentral.Reporting.Models.Intervention;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IInterventionRepo _interventionRep;
        public InterventionController(ILoggerManager logger
            , IConfiguration config
            , IInterventionRepo interventionRep)
        {
            _configuration = config;
            _logger = logger;
            _interventionRep = interventionRep;
        }


        [HttpGet(Name = "SyncAllInterventions")]
        public async Task<IActionResult> Get(int offSet=0,int limit=150)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {

                InterventionModel Interventions = new InterventionModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/interventions?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Interventions = JsonConvert.DeserializeObject<InterventionModel>(apiResponse);

                        if (Interventions is not null && Interventions.records is not null && Interventions.records.Count > 0)
                        {
                            int SavedRecords=await _interventionRep.CountAsync();
                            if (SavedRecords < Interventions.count)
                            {
                                //for(int i=SavedRecords; SavedRecords < Interventions.count; i+=limit)
                                //{
                                    while (SavedRecords < Interventions.count)
                                    {
                                        int page = SavedRecords > 0 ? SavedRecords / limit : 0;
                                    if(SavedRecords>0 && Interventions.count-SavedRecords<limit)
                                    {
                                        limit = (int)Interventions.count - SavedRecords;
                                    }
                                        await Save(page, limit);
                                        SavedRecords = await _interventionRep.CountAsync();
                                    }
                                //}
                                
                            }
                            else
                            {
                                return Ok(SyncStatuts);
                            }
                            //SyncStatuts =  await _interventionRep.SyncIntervention(JsonConvert.SerializeObject(Interventions.records));
                            //SyncStatuts.Count = Interventions.count;

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

        [HttpGet ("{offset}/{limit}")]
        public async Task<IActionResult> Save([FromRoute] int offSet = 0,[FromRoute] int limit = 30)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {

                InterventionModel Interventions = new InterventionModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/interventions?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Interventions = JsonConvert.DeserializeObject<InterventionModel>(apiResponse);

                        if (Interventions is not null && Interventions.records is not null && Interventions.records.Count > 0)
                        {
                            SyncStatuts = await _interventionRep.SyncIntervention(JsonConvert.SerializeObject(Interventions.records));
                            SyncStatuts.Count = Interventions.count;

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
