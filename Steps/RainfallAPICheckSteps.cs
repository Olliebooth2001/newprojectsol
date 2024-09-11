using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace ApiTests.StepDefinitions
{
    [Binding]
    public class RainfallAPICheckSteps
    {
        private HttpClient _client;
        private HttpResponseMessage _response;
        private JArray _responseBodyArray;

        // Constructor
        public RainfallAPICheckSteps()
        {
            _client = new HttpClient();
        }

        // Destructor
        ~RainfallAPICheckSteps()
        {
            _client.Dispose();
        }

        [Given(@"I have the API endpoint")]
        public void GivenIHaveTheAPIEndpoint()
        {
            string baseUrl = "http://environment.data.gov.uk/flood-monitoring/id/stations";
            _client.BaseAddress = new System.Uri(baseUrl);
        }

        [When(@"I send a GET request to the API with a valid integer for limit")]
        public async Task WhenISendAGETRequestToTheAPIWithAValidIntegerForLimit()
        {
            _response = await _client.GetAsync("?parameter=rainfall&_limit=5"); 
        }

        //Sending req with a valid set of parameters to be validated
        [When(@"I send a GET request to the API with a limit of 5")]
        public async Task WhenISendAGETRequestToTheAPIWithALimitOf5()
        {
            _response = await _client.GetAsync("?parameter=rainfall&_limit=5");
            var responseContent = await _response.Content.ReadAsStringAsync();
            _responseBodyArray = JObject.Parse(responseContent)["items"] as JArray;
        }

        // Sending a req with the station appended
        [When(@"I send a GET request to the API with a station specified")]
        public async Task WhenISendAGETRequestToTheAPIWithAStationSpecified()
        {
            string station = "3680";
            string fullUrl = $"{_client.BaseAddress}/{station}/measures";
            _response = await _client.GetAsync(fullUrl);
        }

        //Sending req with station and date specified
        [When(@"I send a GET request to the API with a station specified and a date")]
        public async Task WhenISendAGETRequestToTheAPIWithAStationSpecifiedAndADate()
        {
            string station = "3680";
            string date = "2024-10-10";
            string fullUrl = $"{_client.BaseAddress}/{station}/measures?date={date}";
            _response = await _client.GetAsync(fullUrl);
        }

        // Sending req with invalid date to invoke a bad request status
        [When(@"I send a GET request to the API with an invalid station specified")]
        public async Task WhenISendAGETRequestToTheAPIWithAnInvalidStationSpecified()
        {
            string station = "invalidStation";
            string fullUrl = $"{_client.BaseAddress}/{station}";
            _response = await _client.GetAsync(fullUrl);        
        }

        // Sending req with invalid parameter to invoke a bad request status
        [When(@"I send a GET request with an invalid parameter")]
        public async Task WhenISendAGETRequestWithAnInvalidParameter()
        {
            _response = await _client.GetAsync("?_limit=xyz"); // Invalid query parameter
        }

        // Step to assert that the response contains 5 items
        [Then(@"the response should contain 5 items")]
        public void ThenTheResponseShouldContain5Items()
        {
            Assert.IsNotNull(_responseBodyArray, "Response is null");
            Assert.AreEqual(5, _responseBodyArray.Count, "Expected the array to contain 5 items");
        }

        // Step to assert that the response status matches the expected status code
        [Then(@"I should receive a response with status (.*)")]
        public void ThenIShouldReceiveAResponseWithStatus(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode, $"Expected: {expectedStatusCode}, Actual: {(int)_response.StatusCode}");
        }
    }
}
