using RingCentral.Reporting.Data.Repository.Interfaces;

namespace RingCentral.Reporting.API
{
    public class IntegrationProcess: ISyncAllData
    {
        private readonly IConfiguration _configuration;
        public IntegrationProcess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CallAsync()
        {
            string host = _configuration["Host:URL"];
            var requestUrl = host+"api/Intervention";
            var threadRequestUrl = host + "api/Threads";
            var identitiesRequestUrl = host + "api/Identities";
            var identitiesGroupRequestUrl = host + "api/IdentityGroup";
            var interventionCommentRequestUrl = host + "api/InterventionComment";
            var sourceRequestUrl = host + "api/Source";
            var categoriesRequestUrl = host + "api/Categories";

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient _httpClient = new HttpClient(clientHandler);
            _httpClient.Timeout=TimeSpan.FromMinutes(30);
            try
            {
                List<Task> runAll = new List<Task>();
                runAll.Add(_httpClient.GetAsync(categoriesRequestUrl));
                runAll.Add(_httpClient.GetAsync(requestUrl));
                runAll.Add(_httpClient.GetAsync(threadRequestUrl));
                runAll.Add(_httpClient.GetAsync(identitiesRequestUrl));
                runAll.Add(_httpClient.GetAsync(identitiesGroupRequestUrl));
                runAll.Add(_httpClient.GetAsync(interventionCommentRequestUrl));
                runAll.Add(_httpClient.GetAsync(sourceRequestUrl));
                await Task.WhenAll(runAll);
                //var categoriesResponse = await _httpClient.GetAsync(categoriesRequestUrl);
                //var response = await _httpClient.GetAsync(requestUrl);
                //var threadResponse = await _httpClient.GetAsync(threadRequestUrl);
                //var identitiesResponse = await _httpClient.GetAsync(identitiesRequestUrl);
                //var identitiesGroupResponse = await _httpClient.GetAsync(identitiesGroupRequestUrl);
                //var interventionCommentResponse = await _httpClient.GetAsync(interventionCommentRequestUrl);
                //var sourceResponse = await _httpClient.GetAsync(sourceRequestUrl);
                return "";
            }
            catch(AggregateException ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
