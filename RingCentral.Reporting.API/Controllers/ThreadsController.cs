using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RingCentral.Reporting.Data.Repository;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Models.Interfaces;
using RingCentral.Reporting.Data.Repository.Interfaces;
using System.Net.Http.Headers;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IThreadRepo _threadRepo;

        public ThreadsController(ILoggerManager logger, IConfiguration config, IThreadRepo threadRepo)
        {
            _configuration = config;
            _logger = logger;
            _threadRepo = threadRepo;
        }


        [HttpGet(Name = "SyncAllThreads")]
        public async Task<IActionResult> Get(int offSet=0,int limit=150)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {
                
                ThreadModel Threads = new ThreadModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/content_threads?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Threads = JsonConvert.DeserializeObject<ThreadModel>(apiResponse);

                        if (Threads is not null && Threads.records is not null && Threads.records.Count > 0)
                        {
                            // Insert thread into database table

                            //SyncStatuts =  await _threadRepo.SyncThread(JsonConvert.SerializeObject(Threads.records));
                            //SyncStatuts.Count = Threads.count;
                            int SavedRecords = await _threadRepo.CountAsync();
                            if (SavedRecords < Threads.count)
                            {
                                while (SavedRecords < Threads.count)
                                {
                                    int page = SavedRecords > 0 ? SavedRecords / limit : 0;
                                    if (SavedRecords > 0 && Threads.count - SavedRecords < limit)
                                    {
                                        limit = (int)Threads.count - SavedRecords;
                                    }
                                    await Save(page, limit);
                                    SavedRecords = await _threadRepo.CountAsync();
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

                ThreadModel Threads = new ThreadModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/content_threads?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Threads = JsonConvert.DeserializeObject<ThreadModel>(apiResponse);

                        if (Threads is not null && Threads.records is not null && Threads.records.Count > 0)
                        {
                            // Insert thread into database table

                            SyncStatuts = await _threadRepo.SyncThread(JsonConvert.SerializeObject(Threads.records));
                            SyncStatuts.Count = Threads.count;

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
