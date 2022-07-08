using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RingCentral.Reporting.Data.Repository;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Models.Interfaces;
using RingCentral.Reporting.Data.Repository.Interfaces;
using System.Net.Http.Headers;
using RingCentral.Reporting.Models.Sources;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly ISourceRepo _sourceRepo;

        public SourceController(ILoggerManager logger, IConfiguration config, ISourceRepo sourceRepo)
        {
            _configuration = config;
            _logger = logger;
            _sourceRepo = sourceRepo;
        }


        [HttpGet(Name = "SyncAllSource")]
        public async Task<IActionResult> Get(int offSet=0,int limit=150)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {
                
                SourceModel Source = new SourceModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/content_sources?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Source = JsonConvert.DeserializeObject<SourceModel>(apiResponse);

                        if (Source is not null && Source.records is not null && Source.records.Count > 0)
                        {
                            // Insert thread into database table

                            //SyncStatuts =  await _threadRepo.SyncThread(JsonConvert.SerializeObject(Source.records));
                            //SyncStatuts.Count = Source.count;
                            int SavedRecords = await _sourceRepo.CountAsync();
                            if (SavedRecords < Source.count)
                            {
                                while (SavedRecords < Source.count)
                                {
                                    int page = SavedRecords > 0 ? SavedRecords / limit : 0;
                                    if (SavedRecords > 0 && Source.count - SavedRecords < limit)
                                    {
                                        limit = (int)Source.count - SavedRecords;
                                    }
                                    await Save(page, limit);
                                    SavedRecords = await _sourceRepo.CountAsync();
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

                SourceModel Source = new SourceModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/content_sources?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Source = JsonConvert.DeserializeObject<SourceModel>(apiResponse);

                        if (Source is not null && Source.records is not null && Source.records.Count > 0)
                        {
                            // Insert thread into database table

                            SyncStatuts = await _sourceRepo.SyncSource(JsonConvert.SerializeObject(Source.records));
                            SyncStatuts.Count = Source.count;

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
