using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RingCentral.Reporting.Data.Repository;
using RingCentral.Reporting.Models;
using RingCentral.Reporting.Models.Interfaces;
using RingCentral.Reporting.Data.Repository.Interfaces;
using System.Net.Http.Headers;
using RingCentral.Reporting.Models.Categories;

namespace RingCentral.Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly ICategoriesRepo _CategoriesRepo;

        public CategoriesController(ILoggerManager logger, IConfiguration config, ICategoriesRepo CategoriesRepo)
        {
            _configuration = config;
            _logger = logger;
            _CategoriesRepo = CategoriesRepo;
        }


        [HttpGet(Name = "SyncAllCategories")]
        public async Task<IActionResult> Get(int offSet=0,int limit=150)
        {

            SyncStatuts SyncStatuts = new SyncStatuts();
            try
            {
                
                CategoriesModel Categories = new CategoriesModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/categories?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Categories = JsonConvert.DeserializeObject<CategoriesModel>(apiResponse);

                        if (Categories is not null && Categories.records is not null && Categories.records.Count > 0)
                        {
                            // Insert thread into database table

                            //SyncStatuts =  await _threadRepo.SyncThread(JsonConvert.SerializeObject(Categories.records));
                            //SyncStatuts.Count = Categories.count;
                            int SavedRecords = await _CategoriesRepo.CountAsync();
                            if (SavedRecords < Categories.count)
                            {
                                while (SavedRecords < Categories.count)
                                {
                                    int page = SavedRecords > 0 ? SavedRecords / limit : 0;
                                    if (SavedRecords > 0 && Categories.count - SavedRecords < limit)
                                    {
                                        limit = (int)Categories.count - SavedRecords;
                                    }
                                    await Save(page, limit);
                                    SavedRecords = await _CategoriesRepo.CountAsync();
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

                CategoriesModel Categories = new CategoriesModel();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN);


                    using (var response = await httpClient.GetAsync($"{RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL}/1.0/categories?offset={offSet}&limit={limit}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Categories = JsonConvert.DeserializeObject<CategoriesModel>(apiResponse);

                        if (Categories is not null && Categories.records is not null && Categories.records.Count > 0)
                        {
                            // Insert thread into database table

                            SyncStatuts = await _CategoriesRepo.SyncCategories(JsonConvert.SerializeObject(Categories.records));
                            SyncStatuts.Count = Categories.count;

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
