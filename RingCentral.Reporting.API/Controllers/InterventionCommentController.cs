using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RingCentral.Reporting.Data.Repository.Interfaces;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Models.Interfaces;
using RingCentral.Reporting.Models.InterventionComment;
using System.Net.Http.Headers;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionCommentController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IInterventionCommentRepo _interventionCommentRep;

        public InterventionCommentController(ILoggerManager logger, IConfiguration config, IInterventionCommentRepo interventionCommentRep)
        {
            _configuration = config;
            _logger = logger;
            _interventionCommentRep = interventionCommentRep;
        }


        [HttpGet(Name = "SyncAllInterventionComments")]
        public async Task<IActionResult> Get(int offSet = 0, int limit = 30)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {

                InterventionCommentModel InterventionComment = new InterventionCommentModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/intervention_comments?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        InterventionComment = JsonConvert.DeserializeObject<InterventionCommentModel>(apiResponse);

                        if (InterventionComment is not null && InterventionComment.records is not null && InterventionComment.records.Count > 0)
                        {
                            //SyncStatuts = await _interventionCommentRep.SyncInterventionComment(JsonConvert.SerializeObject(InterventionComment.records));
                            //SyncStatuts.Count = InterventionComment.count;

                            int SavedRecords = await _interventionCommentRep.CountAsync();
                            if (SavedRecords < InterventionComment.count)
                            {
                                while (SavedRecords < InterventionComment.count)
                                {
                                    int page = SavedRecords > 0 ? SavedRecords / limit : 0;
                                    if (SavedRecords > 0 && InterventionComment.count - SavedRecords < limit)
                                    {
                                        limit = (int)InterventionComment.count - SavedRecords;
                                    }
                                    await Save(page, limit);
                                    SavedRecords = await _interventionCommentRep.CountAsync();
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

                InterventionCommentModel InterventionComment = new InterventionCommentModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/intervention_comments?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        InterventionComment = JsonConvert.DeserializeObject<InterventionCommentModel>(apiResponse);

                        if (InterventionComment is not null && InterventionComment.records is not null && InterventionComment.records.Count > 0)
                        {
                            SyncStatuts = await _interventionCommentRep.SyncInterventionComment(JsonConvert.SerializeObject(InterventionComment.records));
                            SyncStatuts.Count = InterventionComment.count;

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
